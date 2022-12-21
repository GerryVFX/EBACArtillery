using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject explotionParticles;
    CameraFollow cam;

    private void Start()
    {
        cam = FindObjectOfType<CameraFollow>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        cam.returnCannon = true;
        Destroy(gameObject, 0.2f);
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
