using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanionController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawner;
    float rotation;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameManager.instance._shoots -= 1;

                GameObject temp = Instantiate(bulletPrefab, bulletSpawner.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                Vector3 shootDirection = transform.rotation.eulerAngles;
                shootDirection.y = 90 - shootDirection.x;
                tempRB.velocity = shootDirection.normalized * GameManager.instance._bulletSpeed;
            }
        }
    }
}
