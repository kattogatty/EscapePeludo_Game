using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShieldPlayer : MonoBehaviour
{
    public int currentShield; //vida actual del player
    public int maxiShield; // vida maxima del player
    public UnityEvent<int> changeShield; 
    private bool shieldActive = false;
    public int valorPrueba;

    public Shield shieldScript; 

    void Start()
    {
        currentShield = maxiShield; 
        changeShield.Invoke(currentShield); 

           if (shieldScript == null)
        {
            shieldScript = GetComponentInChildren<Shield>();
        }
    }

  private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Recollection(valorPrueba);
        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            ShieldRecovery(valorPrueba);
        }
    }

   public void Recollection (int recollectionAmount) //metodo de cantidad de recoleccion  
   {
    if (!shieldActive) 
    {
        int tempShield =  currentShield - recollectionAmount; 
        if(tempShield < 0)
        {
         currentShield = 0;
        }
        else 
        {
            currentShield = tempShield;
        }

        changeShield.Invoke(currentShield);

        if(currentShield <= 0)
        {
            if (shieldScript != null)
            {
                shieldScript.ActivateShield(); 
            }
            
        }
   
    }
 
   }

      public void ShieldRecovery (int shieldAmount)
    {
        int tempShield = currentShield + shieldAmount;

        if(tempShield > maxiShield)
        {
            //tempShield = maxiShield; 
            currentShield = maxiShield;
        }
        else
        {
            currentShield = tempShield; 
        }
        changeShield.Invoke(currentShield);
    }
  
}
