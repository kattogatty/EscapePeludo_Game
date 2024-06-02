using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 

public class SaveandLoad : MonoBehaviour
{
    public GameObject jugador; // referencia al jugador 
    public string FileSave; // archivo para sobreescribir y leer
    public DataGame dataGame = new DataGame(); 
    private void Awake() 
    {
        FileSave = Application.dataPath + "/dataGame.json";
        jugador = GameObject.FindGameObjectWithTag("Player"); 
        //CargarDatos (); 
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            LoadData(); 
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            SaveData(); 
        }
    }

    private void LoadData()
    {
        if (File.Exists(FileSave))
        {
            string contenido = File.ReadAllText(FileSave);
            dataGame = JsonUtility.FromJson<DataGame>(contenido); 

            Debug.Log("Posicion Jugador :" + dataGame.posicion); 

            jugador.transform.position = dataGame.posicion; 
            jugador.GetComponent<EnergyPlayer>().currentEnergy = dataGame.energy;
        }
        else
        {
            Debug.Log("El archivo no existe"); 
        }
    }

    private void SaveData()
    {
        DataGame newData = new DataGame()
        {
            posicion = jugador.transform.position,
            energy = jugador.GetComponent<EnergyPlayer>().currentEnergy

        };

        string cadenaJSON = JsonUtility.ToJson(newData);
        File.WriteAllText(FileSave, cadenaJSON); 
        Debug.Log("Archivo guardado");
    }

}

[System.Serializable] // para que se logre ver en el inspector 
public class DataGame 
{
    public Vector3 posicion; 
    public int energy; 
}

