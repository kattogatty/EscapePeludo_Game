using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySem : MonoBehaviour
{
      public int Healing;  
     private void OnTriggerEnter(Collider other)
   {
     if (other.TryGetComponent(out EnergyPlayer energyPlayer))
     {
        energyPlayer.healEnergy(Healing); 
     }
   } 
}
