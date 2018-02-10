using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeBox : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
    }

    public void ShowDialougeBox()
    {
        animator.SetBool("isOpen", true);
    }

    public void HideDialougeBox()
    {
        // animator.SetBool("hideBox", true);
        animator.SetBool("isOpen", false);
    }
    public bool IsBoxActive()
    {
        return animator.GetBool("hideBox"); 
    }

}
