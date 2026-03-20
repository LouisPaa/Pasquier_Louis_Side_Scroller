using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject _Chara;
    float Barredevie;
    float MaxHP;
    Image slider;

    private void Awake() // Récupère l'image du foreground de la barre de vie 
    {
        slider = GetComponent<Image>();
    }

    private void Start() // Récupère les PV max du joueur dès le lancement du jeu 
    {
        MaxHP = _Chara.GetComponent<CharaHealth>()._maxHealth;
    }

    public void setSlider() // Permet de lier le slider de la barre de vie aux PV du joueur 
    {
        Barredevie = _Chara.GetComponent<CharaHealth>()._currentHealth / MaxHP * 1;
        slider.fillAmount = Barredevie;
    }
}
