using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 



public class EnergyPlayer : MonoBehaviour
{
    public int currentEnergy; //vida actual del player
    public int maxiEnergy; // vida maxima del player
    public UnityEvent<int> changeEnergy; 
    public int valorPrueba;

    private Animator animator; 
    public GameObject pausePanel; 

    void Start()
    {
        currentEnergy = maxiEnergy; 
        changeEnergy.Invoke(currentEnergy); 

        animator = GetComponent<Animator>(); 
        pausePanel.SetActive(false);
    }

    private void Update() 
    {
         if(Input.GetKeyDown(KeyCode.N))
        {
            Damage(valorPrueba);
        }
         if(Input.GetKeyDown(KeyCode.M))
        {
            healEnergy(valorPrueba);
        }
    }

   public void Damage(int damageAmount) //metodo de cantida de daño 
   {
    int tempEnergy =  currentEnergy - damageAmount; 
    if(tempEnergy <0)
    {
        currentEnergy = 0;
    }
    else 
    {
        currentEnergy = tempEnergy;
    }

    changeEnergy.Invoke(currentEnergy);

    if(currentEnergy <= 0)
    {
       Die(); //destruye el objeto despues de que la energia llega a 0
    }
   }

   public void healEnergy (int healAmount) // metodo para recueperacion de energia 
   {
    int tempEnergy = currentEnergy + healAmount; 

    if(tempEnergy > maxiEnergy)
    {
        currentEnergy = maxiEnergy; 
    }
    else
    {
        currentEnergy = tempEnergy;
    }

    changeEnergy.Invoke(currentEnergy);

   }
   private void Die()
   {
    animator.SetTrigger("Dead"); //Dispara animacion de muerte; 
    StartCoroutine(ShowPausePanel());
   }

   private IEnumerator ShowPausePanel()
   {
    yield return new WaitForSeconds(5f);
    pausePanel.SetActive(true); 
   }
}
