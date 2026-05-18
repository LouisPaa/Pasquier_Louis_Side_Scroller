using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour  
{
    
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    public void Start() // Récupère les résolutions disponibles sur l'ordinateur du joueur et les ajoute au menu déroulant des résolutions
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
        }

        resolutionDropdown.AddOptions(options);
    }

    public void SetVolume(float volume) // Permet de régler le volume du jeu en fonction de la valeur du slider
    {
        audioMixer.SetFloat("volume", volume);
    }


    public void SetFullScreen(bool isFullScreen) // Permet de basculer entre le mode plein écran et le mode fenêtré 
    {
        Screen.fullScreen = isFullScreen;
    }
}
