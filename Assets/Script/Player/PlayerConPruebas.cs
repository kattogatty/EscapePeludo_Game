using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConPruebas : MonoBehaviour
{
   private Animator playerAnimator;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerAnimator. SetFloat("YSpeed", Input.GetAxis("Vertical"));
        playerAnimator. SetFloat("XSpeed", Input.GetAxis("Horizontal")); 
    

        if(Input.GetKeyDown(KeyCode.A)) playerAnimator.SetTrigger("Jump");
        if(Input.GetKeyDown(KeyCode.LeftShift)) playerAnimator.SetTrigger("Run");
        if(Input.GetKeyDown(KeyCode.W)) playerAnimator.SetTrigger("Punch");
        
    }
}
