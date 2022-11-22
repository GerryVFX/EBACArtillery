using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Lógica para Ganar
    public bool levelWin;

    //Variables Get y Set
    float bulletSpeed = 13f; 
    public float _bulletSpeed { get => bulletSpeed; }

    float turnSpeed = 1f;
    public float _turnSpeed { get => turnSpeed; }

    int shoots = 5;
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
    }
}
