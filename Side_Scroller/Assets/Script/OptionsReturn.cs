using UnityEngine;
using UnityEngine.SceneManagement;
public class OptionsReturn : MonoBehaviour
{
 // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
