using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Lógica para Ganar
    public bool levelWin;

    public bool unlock2, unlock3, unlock4, unlock5, unlock6; //Para saber que nivel desbloqueamos;

    public int currentLevel;
    public bool inMain, inGame;

    public int pts1, pts2, pts3, pts4, pts5, pts6;

    [SerializeField] GameObject[] levels;
    public int targetForWin;

    //SoundSettings

    AudioSource mainBGMusic; 

    public float bgVolume;
    public float fxVolume;

    //Variables de uso para el player
    float bulletSpeed = 0f; 
    public float _bulletSpeed { get => bulletSpeed; set => bulletSpeed = value; }

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
            mainBGMusic.Stop();
        }
        else
        {
            if(mainBGMusic.isPlaying==false)
            mainBGMusic.Play();
        }

        mainBGMusic.volume = bgVolume;
    }

    public void RecetValues()
    {
        targetForWin = levels[currentLevel].transform.childCount;
        _shoots = 10;
    }
}
