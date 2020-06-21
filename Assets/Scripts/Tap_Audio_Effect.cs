using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap_Audio_Effect : MonoBehaviour
{
    public AudioClip palyOnceSound;
    public AudioClip winSound;
    public AudioClip missSound;
    private AudioSource _audioSource;

    public static Tap_Audio_Effect _instance;

    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;

        _audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    public void Tap_Music_Effect()
    {
        _audioSource.PlayOneShot(palyOnceSound, 1f);
    }
    public void Miss_Effect()
    {
        _audioSource.PlayOneShot(missSound,1f);
    }
    public void Win_Effect()
    {
        _audioSource.PlayOneShot(winSound,0.7f);
    }
}
