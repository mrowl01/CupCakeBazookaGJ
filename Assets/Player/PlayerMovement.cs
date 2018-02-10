using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //todo consider having two movement scripts on the character to handle minigame movement vs movement in main scenes
    Rigidbody2D rigidBody = null;

    [SerializeField] float speed = 3f;
    [SerializeField] float jumpStrength = 3f;
    [SerializeField] float distanceOfRaycast = 5.0f;
    bool isCharacterGrounded = true;
 


    public LayerMask groundLayer; 


    // todo make is minigame private - accessable for playtest purposes
    [SerializeField] bool isPlayerInMiniGame = false;
    [SerializeField]bool isJumping = false;

    //todo: For later use to handle animation
    public enum Direction { UP, DOWN, LEFT, RIGHT, IDLE }

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isCharacterGrounded = IsGrounded(); 

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //If player not in mini game do normal movement
        if (isPlayerInMiniGame == false)
        {
            //set gravity scale to zero so it can explore tile maps
            rigidBody.gravityScale = 0; 
            Vector2 movement = GetPlayerInput(moveHorizontal, moveVertical);
            rigidBody.velocity = movement; 
        }
        // else it will use other movement
        if (isPlayerInMiniGame == true)
        {
            if (isCharacterGrounded == true)
            {
                Vector2 movement = HoriMovement(moveHorizontal);
                rigidBody.velocity = movement;
                Jumping();
            }
        }

    }

    #region player not in mini game movement 

    Vector2 GetPlayerInput(float moveHorizontal, float moveVertical)
    {
        //handles inproper imput 
        if (-1 > moveHorizontal || moveHorizontal > 1 || -1 > moveVertical || moveVertical > 1)
        {
            throw new System.ArgumentOutOfRangeException("Improper movement input, require axis's between -1 and 1");
        }
        //todo: handle if player is on edge of map

        //handles the movement update
        Vector2 movementUpdate = new Vector2(0, 0);
        //sets the update
        movementUpdate.x += moveHorizontal * speed;
        movementUpdate.y += moveVertical * speed;

        return movementUpdate;
    }

    #endregion 

    #region Player in mini game 

    Vector2 HoriMovement(float moveHorizontal)
    {
        rigidBody.isKinematic = false; 
        Vector2 movementUpdate = new Vector2(0, 0);
        //sets the update
        movementUpdate.x += moveHorizontal * speed;
        return movementUpdate;
    }
    void Jumping()
    {
        if (Input.GetButtonDown("Jump") )
        {
            rigidBody.AddForce(transform.up * jumpStrength);
        }
    }

    
    public bool IsGrounded()
    {
        Vector2 postion = transform.position;
        Vector2 direction = Vector2.down;

        Debug.DrawRay( transform.position , direction * distanceOfRaycast, Color.green); 
        RaycastHit2D hit = Physics2D.Raycast(postion, direction, distanceOfRaycast, groundLayer);
        //todo remove debugline; only here to see what the distance of ground check is 
       
        if (hit.collider != null)
        {
            print("Hit something" + hit.collider.gameObject);
            return true;
        }
        return false; 
    }
    
    #endregion


}
