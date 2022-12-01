using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] sounds;
    [SerializeField]AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else return;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShoot()
    {
        audioSource.PlayOneShot(sounds[0]);
    }

    public void PlayExposion()
    {
        audioSource.PlayOneShot(sounds[1]);
    }
}