using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Effect : MonoBehaviour
{
    public AudioClip palyOnceSound;
    public AudioClip winSound;
    private AudioSource _audioSource;

    public static Music_Effect _instance;

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
    public void Win_Effect()
    {
        _audioSource.PlayOneShot(winSound,0.7f);
    }
}
