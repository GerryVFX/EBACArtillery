using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanionController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject particles;
    [SerializeField] Transform bulletSpawner;
    float rotation;

    public static bool blocking;

    void Update()
    {
        rotation += Input.GetAxis("Horizontal") * GameManager.instance._turnSpeed;

        if(rotation <= 90 && rotation >= 0)
        {
            transform.eulerAngles = new Vector3(rotation, 90, 0);
        }

        if (rotation > 90) rotation = 90;
        if (rotation < 0) rotation = 0;

        if (GameManager.instance._shoots > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !blocking)
            {
                GameManager.instance._shoots -= 1;

                AudioManager.instance.PlayShoot();

                GameObject temp = Instantiate(bulletPrefab, bulletSpawner.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                CameraFollow.target = temp;

                Vector3 shootDirection = transform.rotation.eulerAngles;
                shootDirection.y = 90 - shootDirection.x;
                Vector3 particlesDirection = new Vector3(-90 + shootDirection.x, 90, 0);
                GameObject particlesClon = Instantiate(particles, bulletSpawner.position, Quaternion.Euler(particlesDirection), transform);
                tempRB.velocity = shootDirection.normalized * GameManager.instance._bulletSpeed;

                blocking = true;
            }
        }
    }
}
