using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCereal : MonoBehaviour
{
    public int Recovery;  
     private void OnTriggerEnter(Collider other)
   {
     if (other.TryGetComponent(out ShieldPlayer shieldPlayer))
     {
          shieldPlayer.Recollection(Recovery);  
     }
   } 
}
