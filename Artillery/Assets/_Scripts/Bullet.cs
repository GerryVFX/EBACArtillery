using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    MeshRenderer myrenderer;
    [SerializeField] GameObject explotionParticles;

    private void OnCollisionEnter(Collision collision)
    {
        //myrenderer.enabled = false;
        Destroy(gameObject);
        GameManager.instance._shoots -= 1;
        Instantiate(explotionParticles, transform.position, Quaternion.identity);
        

        
        if (collision.gameObject.CompareTag("Core"))
        {
            GameManager.instance.targetForWin -= 1;
            AudioManager.instance.PlayExposion();
            Destroy(collision.gameObject);
            GameManager.instance.levelWin = true;
        }
    }
}
