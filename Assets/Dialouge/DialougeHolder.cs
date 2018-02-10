using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeHolder : MonoBehaviour
{

    public string dialouge;
    DialougeBoss dBoss;

    //had to add this bool to fix a bug where pressing a button also closed and opened at same time
    public bool interacted = false; 


	// Use this for initialization
	void Start ()
    {
        dBoss = FindObjectOfType<DialougeBoss>();
       
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && interacted == false)
        {
            print("Trigger activated");
            if (Input.GetButtonUp("Jump") && interacted== false )
            {
                dBoss.UpdateDialouge(dialouge);
                interacted = true; 
            }
        }
    }


    // Update is called once per frame
    void Update ()
    {

        print(interacted);
		
	}
}
