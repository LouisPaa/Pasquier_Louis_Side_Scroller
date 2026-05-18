using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionsReturn : MonoBehaviour
{
 // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Permet de retourner au menu principal en appuyant sur la touche "Echap"
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
