using UnityEngine;
using Unity.Cinemachine;

public class CameraRegister : MonoBehaviour
{
    private void OnEnable() //permet d'enregistrer la caméra dans le CameraManager 
    {
        CameraManager.Register(GetComponent<CinemachineCamera>());
    }
    private void OnDisable() //permet de désenregistrer la caméra du CameraManager
    {
        CameraManager.Unregister(GetComponent<CinemachineCamera>());
    }
}
