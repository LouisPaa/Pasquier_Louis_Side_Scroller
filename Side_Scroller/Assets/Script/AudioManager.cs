using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Sources")]
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip background; 
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip dash;
    public AudioClip attack;

    [Header("Volume")]
    [SerializeField] private float backgroundVolume = 0.5f;
    [SerializeField] private float jumpVolume = 0.5f;
    [SerializeField] private float walkVolume = 0.5f;
    [SerializeField] private float dashVolume = 0.5f;
    [SerializeField] private float attackVolume = 0.5f;

    private void Start()
    {
        SFXSource.clip = background;
        SFXSource.volume = backgroundVolume;
        SFXSource.Play();
    }

    public void PlayWalkSound()
    {
        SFXSource.PlayOneShot(walk, walkVolume);
    }

    public void PlayJumpSound()
    {
        SFXSource.PlayOneShot(jump, jumpVolume);
    }

    public void PlayAttackSound()
    {
        SFXSource.PlayOneShot(attack, attackVolume);  
    }

    public void PlayDashSound()
    {
        SFXSource.PlayOneShot(dash, dashVolume);
    }


}
