using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PauseController : MonoBehaviour
{
    public static bool IsGamePaused { get; private set; } = false;

    public static void SetPause(bool pause) // Permet de mettre le jeu en pause ou de le reprendre 
    {
        IsGamePaused = pause;
    }
}
