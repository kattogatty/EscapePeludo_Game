using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyController : MonoBehaviour
{
    private Animator boyAnimator;
    void Start()
    {
        boyAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)) boyAnimator.SetTrigger("Throw");
        
    }
}
