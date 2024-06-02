using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
 
 public int punch; 
 void Start ()
    {
         Destroy(gameObject,3); //el objeto se destruye despues de 3 segundos 
    }
    private void OnTriggerEnter(Collider other) 
    
     {
        if (other.gameObject.TryGetComponent<EnergyPlayer>(out EnergyPlayer energyBullet))
            {
                 energyBullet.Damage(punch);
            }
                Destroy(gameObject); 

    }
}
    

