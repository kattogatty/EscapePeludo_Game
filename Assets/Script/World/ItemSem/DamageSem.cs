using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSem : MonoBehaviour
{
    public int punch;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnergyPlayer energyPlayer))
        {
            energyPlayer.Damage(punch);
        }
    }
}
