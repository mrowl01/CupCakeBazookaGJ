using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialougeBoss : MonoBehaviour
{

    public Text dtext;
    DialougeBox dBox; // dbox for dialouge box
    DialougeHolder resetInteract; 

    public bool isBoxActive;

    private void Start()
    {
        dBox = FindObjectOfType<DialougeBox>();
        resetInteract = FindObjectOfType<DialougeHolder>();
    }

    private void Update()
    {
        //isBoxActive = dBox.IsBoxActive();
       // print(isBoxActive); 
        
        //if box is active and we press space, close
        //todo: fix the problem where pressing down spacebar doesn't make the dialouge appear
        if (isBoxActive && Input.GetKeyUp(KeyCode.A))
        {
     
            dBox.HideDialougeBox();
            isBoxActive = false;
            resetInteract.interacted = false;

        }
    }

    public void UpdateDialouge(string dialouge)
    {
        // if box is not active, show the dialouge
        
            dtext.text = dialouge;
            dBox.ShowDialougeBox();
            isBoxActive = true;
        
    }

}
