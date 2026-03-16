using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject _Chara;
    float Barredevie;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        Barredevie = _Chara.GetComponent<CharaHealth>()._currentHealth;
        slider.value = Barredevie;
    }
}
