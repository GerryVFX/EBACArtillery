using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CanionController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject particles;
    [SerializeField] Transform bulletSpawner;
    float rotation;

    UIManager uiManager;

    public float testForce;

    public PlayerControls playerControls;
    InputAction aim, force, shoot;

    public static bool blocking;

    private void Awake()
    {
        
    }


    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        playerControls = new PlayerControls();
        playerControls.Canon.Enable();
        playerControls.Canon.Shoot.canceled += ctx => Shooting();
    }
    
    private void OnEnable()
    {
        aim = playerControls.Canon.Aim;
        force = playerControls.Canon.ForceShoot;
        shoot = playerControls.Canon.Shoot;


        aim.Enable();
        force.Enable();
    }

    void Update()
    {
        rotation += aim.ReadValue<float>() * GameManager.instance._turnSpeed;

        if (rotation <= 90 && rotation >= 0)
        {
            transform.eulerAngles = new Vector3(rotation, 90, 0);
        }

        if (rotation > 90) rotation = 90;
        if (rotation < 0) rotation = 0;


        if (shoot.IsPressed())
        {
            ChargeForce();
        }

        testForce = GameManager.instance._bulletSpeed;
    }

    public void ChargeForce()
    {
        if (uiManager.inMenu == false && GameManager.instance.gameStart == true && GameManager.instance.gameFinish == false)
        {
            if (GameManager.instance.canShoot)
            {
                GameManager.instance._bulletSpeed += Time.deltaTime * 5;
                if (GameManager.instance._bulletSpeed > 25)
                {
                    GameManager.instance._bulletSpeed = 0;
                }
            }
        }
    }

    private void Shooting()
    {
        if(uiManager.inMenu == false && GameManager.instance.gameStart == true && GameManager.instance.gameFinish == false)
        {
            if (GameManager.instance.canShoot)
            {
                GameManager.instance.canShoot = false;
                AudioManager.instance.PlayShoot();

                GameObject temp = Instantiate(bulletPrefab, bulletSpawner.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                CameraFollow.target = temp;

                Vector3 shootDirection = transform.rotation.eulerAngles;
                shootDirection.y = 90 - shootDirection.x;
                Vector3 particlesDirection = new Vector3(-90 + shootDirection.x, 90, 0);
                GameObject particlesClon = Instantiate(particles, bulletSpawner.position, Quaternion.Euler(particlesDirection), transform);
                tempRB.velocity = shootDirection.normalized * GameManager.instance._bulletSpeed;
                GameManager.instance._bulletSpeed = 0;
                blocking = true;
            }
        }
    }
}
