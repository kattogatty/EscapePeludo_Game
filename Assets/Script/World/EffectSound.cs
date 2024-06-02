using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSound : MonoBehaviour
{
   private AudioSource audioSource;
 
   [SerializeField] private AudioClip KickPunc2; 

   private void OnTriggerEnter(Collider other)
   {
    if(other.CompareTag("Player"))
    {
        ControllSound.Instance.EjecutarSonido(KickPunc2);
        Destroy(gameObject); 
    }
   }

}
