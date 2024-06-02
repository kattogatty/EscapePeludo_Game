using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{
    public GameObject HUDPanel;
    public GameObject pausePanel;
    public Slider MusicSlider;
    public AudioMixer audioMixer;
    private float musicVolume; 
    public string fileName; 
    private AudioSettings audioSettings; 

   
    void Start()
    {
        ShowHUD();
        audioSettings = new AudioSettings(); 
        //GetVolumes();
        LoadAudioSettings(); 
    }

    public void CleanPanel()
    {
        HUDPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    public void ShowHUD()
    {
        CleanPanel();
        HUDPanel.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void ShowPause()
    {
        CleanPanel();
        pausePanel.SetActive(true);
        Time.timeScale = 0.0f;
    }
    
    public void ExitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
    }
    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        audioMixer.SetFloat("MusicVolume", musicVolume); 
        SaveAudioSettings(); 
    }

    public void GetVolumes()
    {
        audioMixer.GetFloat("MusicVolume", out musicVolume);
        MusicSlider.value = musicVolume;
    }
    
    public void SaveAudioSettings()
    {
        //PlayerPrefs.SetFloat("MusicVolume", musicVolume );
        audioSettings.musicVolume = musicVolume; 
        //PlayerPrefs.Save();
        StreamWriter sw = new StreamWriter(fileName, false); 
        sw.Write(JsonUtility.ToJson(audioSettings));
        sw.Close(); 
    }

    public void LoadAudioSettings()
    {
        if (File.Exists(fileName))
        {
            StreamReader sr = new StreamReader(fileName);
            string data = sr.ReadToEnd(); 
            audioSettings = JsonUtility.FromJson<AudioSettings>(data); 
            sr.Close(); 
            musicVolume = audioSettings.musicVolume; 
        }
        else
        {
            audioSettings.musicVolume=0f; 
        }

        MusicSlider.value = musicVolume;
    }
}

public class AudioSettings
{
    public float musicVolume; 
}