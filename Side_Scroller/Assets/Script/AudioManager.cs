using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header ("Audio Sources")]
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip background; 
    public AudioClip jump;
    public AudioClip walk;

    private void Start()
    {
        SFXSource.clip = background;
        SFXSource.Play();
    }

    public void PlayWalkSound()
    {
        SFXSource.PlayOneShot(walk);
    }
}
