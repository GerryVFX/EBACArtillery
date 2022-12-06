using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    MeshRenderer myrenderer;
    [SerializeField] GameObject explotionParticles;

    void Start()
    {
        Destroy(gameObject, 3f);
        myrenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //myrenderer.enabled = false;

        Instantiate(explotionParticles, transform.position, Quaternion.identity);
        

        
        if (collision.gameObject.CompareTag("Core"))
        {
            AudioManager.instance.PlayExposion();
            Destroy(collision.gameObject);
            GameManager.instance.levelWin = true;
        }
    }
}
