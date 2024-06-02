using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; 

public class SemUI : MonoBehaviour
{
  public List<Image>listSem;
  public GameObject SemillaPrefab; 
  public EnergyPlayer energyPlayer;  
  public int indexActual;
  public Sprite SemillaFull;  
  public Sprite SemillaEmpty; 
  
  private void Awake()
  {
    energyPlayer.changeEnergy.AddListener(ChangeSem);
  }

  private void ChangeSem (int currentEnergy) // metodo de cambio de imagen dependiendo la vida actual
  {
    if(!listSem.Any())
    {
        CreateSem(currentEnergy);
    }
    else
    {
        ChangeEnergy(currentEnergy); 
    }
  }

  private void CreateSem(int MaxAmountEnergy) // metodo para crear semillas 
  {
    for (int i = 0; i < MaxAmountEnergy; i++) // se va a repetir la cantidad de veces de la vida del jugador 
    {
        GameObject semilla = Instantiate(SemillaPrefab, transform);
        listSem.Add(semilla.GetComponent<Image>()); // si se tiene otro comportamiento agregarlo en lugar de image
    }

    indexActual = MaxAmountEnergy - 1;     
  }

   private void ChangeEnergy (int currentEnergy)
  {
    if (currentEnergy <= indexActual)
    {
      RemoveEnergy(currentEnergy);
    }
    else
    {
      AddEnergy(currentEnergy); 
    }
  }

  private void RemoveEnergy(int currentEnergy)
  {
    for(int i = indexActual; i >= currentEnergy; i--)
    {
      indexActual = i; 
      listSem[indexActual].sprite = SemillaEmpty;
    }

  }

  private void AddEnergy(int currentEnergy)
  {
    for(int i = indexActual ; i < currentEnergy; i++)
    {
      indexActual = i; 
      listSem[indexActual].sprite = SemillaFull;
    }
  }

}
