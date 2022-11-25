using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    MeshRenderer myrenderer;
    [SerializeField] GameObject explotionParticles;

    void Start()
    {
        Destroy(gameObject, 6.5f);
        myrenderer = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        myrenderer.enabled = false;

            Instantiate(explotionParticles, transform.position, Quaternion.identity);
        

        
        if (collision.gameObject.CompareTag("Core"))
        {
            Destroy(collision.gameObject);
            GameManager.instance.levelWin = true;
        }
    }
}
