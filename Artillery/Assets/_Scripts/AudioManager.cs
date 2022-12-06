using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioClip[] sounds;
    [SerializeField]AudioSource audioSourceFX;
    [SerializeField]AudioSource bgGame;

    private void Awake()
    {
        if (instance == null) instance = this;
        else return;

    }


    private void Start()
    {
        audioSourceFX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audioSourceFX.volume = GameManager.instance.fxVolume;
        bgGame.volume = GameManager.instance.bgVolume;
    }

    public void PlayShoot()
    {
        audioSourceFX.PlayOneShot(sounds[0]);
    }

    public void PlayExposion()
    {
        audioSourceFX.PlayOneShot(sounds[1]);
    }
}
