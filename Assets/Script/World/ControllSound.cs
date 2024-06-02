using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllSound : MonoBehaviour
{
    public static ControllSound Instance;
    private AudioSource audioSource; //referencia al sonido de recoleccion

    private void Awake() //estructura del patron de audio 
    {
        if(Instance == null)  
        {
            Instance = this; // si la instancia es nula permanecera el sonido 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>(); 
        
        if (audioSource == null)
        {
            Debug.LogError("No se encontró AudioSource en el GameObject");
        }
        else
        {
            audioSource.volume = 1.0f; // Asegúrate de que el volumen esté alto
            audioSource.mute = false;  // Asegúrate de que no esté silenciado
        }
    }

    public void EjecutarSonido(AudioClip sonido)
    {
        if (sonido == null)
        {
            Debug.LogError("AudioClip es nulo");
            return;
        }

        Debug.Log("Reproduciendo sonido: " + sonido.name);
        
        audioSource.PlayOneShot(sonido); 
    }

}
