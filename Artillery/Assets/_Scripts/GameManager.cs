using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Lógica para Ganar
    public bool levelWin;

    public bool unlock2, unlock3, unlock4, unlock5, unlock6; //Para saber que nivel desbloqueamos;

    public string currentLevel;
    public bool inMain, inGame;

    public int pts1, pts2, pts3, pts4, pts5, pts6;

    //SoundSettings

    AudioSource mainBGMusic; 

    public float bgVolume;
    public float fxVolume;

    //Variables de uso para el player
    float bulletSpeed = 13f; 
    public float _bulletSpeed { get => bulletSpeed; }

    float turnSpeed = 1f;
    public float _turnSpeed { get => turnSpeed; }

    int shoots = 10;
    public int _shoots
    {
        get => shoots;
        set => shoots = value;
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        mainBGMusic = GetComponent<AudioSource>();
        bgVolume = 0.5f;
        fxVolume = 0.5f;

    }

    private void Update()
    {
        if (inGame)
        {
            mainBGMusic.Pause();
        }
        else mainBGMusic.UnPause();

        mainBGMusic.volume = bgVolume;
    }
}
