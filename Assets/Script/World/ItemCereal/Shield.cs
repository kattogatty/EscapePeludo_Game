using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
   public GameObject objectActandDes; 
   [SerializeField] private AudioClip EffectShield; 
   void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.S))
        {
           ActivateShield();
        }

      if (Input.GetKeyDown(KeyCode.R))
        {
            objectActandDes.SetActive(false);
            StopCoroutine("ActivateAndDesactivate");
         }
    }

    //Funcion para activar el escudo
    public void ActivateShield()
    {
        objectActandDes.SetActive(true);
        StartCoroutine(ActivateAndDesactivate());
        ControllSound.Instance.EjecutarSonido(EffectShield);
    }

     IEnumerator ActivateAndDesactivate()
    {
        yield return new WaitForSeconds(8f);
        objectActandDes.SetActive(false);
    }
  
}
