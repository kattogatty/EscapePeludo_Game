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
public class MainMenuManager : MonoBehaviour
{
   public GameObject StartPanel;
    public GameObject ControlPanel;
    public GameObject CreditPanel; 
    public GameObject HistoryPanel; 
    public Slider MusicSlider;
    public AudioMixer audioMixer; 
    private float musicVolume;

    public string fileName; 
    private AudioSettings audioSettings;  
    void Start ()
    {
        ShowHistoryPanel();
        ShowControlPanel();
        ShowCreditPanel();
        ShowStartPanel();
        audioSettings = new AudioSettings(); 
        //GetVolumes(); 
        LoadAudioSettings(); 
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void CleanPanelStart()
    {
        HistoryPanel.SetActive(false);
        ControlPanel.SetActive(false); 
        CreditPanel.SetActive(false); 
        StartPanel.SetActive(false); 
    }
    
      public void ShowHistoryPanel()
    {
        CleanPanelStart(); 
        HistoryPanel.SetActive(true);
        Time.timeScale = 1.0f; 
    }
    public void ShowControlPanel()
    {
        CleanPanelStart(); 
        ControlPanel.SetActive(true);
        Time.timeScale = 1.0f; 
    }
     public void ShowCreditPanel()
    {
        CleanPanelStart(); 
        CreditPanel.SetActive(true);
        Time.timeScale = 1.0f; 
    }
     public void ShowStartPanel()
    {
        CleanPanelStart(); 
        StartPanel.SetActive(true);
        Time.timeScale = 1.0f; 
    }
   public void SetMusicVolume(float volumen)
   {
    musicVolume = volumen; 
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
        //PlayerPrefs.Save();
        audioSettings.musicVolume = musicVolume; 
        StreamWriter sw = new StreamWriter(fileName, false); 
        sw.Write(JsonUtility.ToJson(audioSettings));
        sw.Close();
    }

    public void LoadAudioSettings()
    {
        
        /*if(PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume"); 
        }
        else
        {
            musicVolume = 0f; 
        }*/

        MusicSlider.value = musicVolume; 
    }    
   public void Exit()
   {
    Application.Quit(); 
   }
}
