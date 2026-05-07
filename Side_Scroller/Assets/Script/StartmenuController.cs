using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class StartmenuController : MonoBehaviour
{
  public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnExitClick()
    {

        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
       
}
