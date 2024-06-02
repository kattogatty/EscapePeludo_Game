using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; 

public class CerealUI : MonoBehaviour
{
  public List<Image> listCereal; // lista de imagenes 
  public GameObject CerealPrefab; // prefab de imagen 
  public ShieldPlayer shieldPlayer;  // Escudo de personaje 
  public int indexActual;
  public Sprite CerealFull;
  public Sprite CerealEmpty;
   
  private void Awake()
  {
    shieldPlayer.changeShield.AddListener(ChangeCereal);
  }

  private void ChangeCereal (int currentShield) // metodo de cambio de imagen dependiendo la vida actual
  {
    if(!listCereal.Any())
    {
        CreateCereal(currentShield);
    }
    else 
    {
      ChangeShield(currentShield);
    }

  }
  private void CreateCereal(int maxAmountShield) // metodo para crear semillas 
  {
    for (int i = 0; i < maxAmountShield; i++) // se va a repetir la cantidad de veces de la vida del jugador 
    {
        GameObject cereal = Instantiate(CerealPrefab, transform);
        listCereal.Add(cereal.GetComponent<Image>()); // si se tiene otro comportamiento agregarlo en lugar de image
    }

    indexActual = maxAmountShield - 1;     
  }

  private void ChangeShield (int currentShield)
  {
    if (currentShield <= indexActual)
    {
      RemoveShield(currentShield);
    }
    else
    {
      AddShield(currentShield); 
    }
  }

  private void RemoveShield(int currentShield)
  {
    for(int i = indexActual; i >= currentShield; i--)
    {
      indexActual = i;
      listCereal[indexActual].sprite = CerealEmpty;
    }
  }

  private void AddShield(int currentShield)
  {
    for(int i = indexActual; i < currentShield; i++)
    {
      indexActual = i;
      listCereal[indexActual].sprite = CerealFull;
    }
  }

}
