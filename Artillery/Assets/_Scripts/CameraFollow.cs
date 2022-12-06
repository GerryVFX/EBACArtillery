using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static GameObject target;
    public GameObject vewtarget;
    public bool isLoock;
    Vector3 destiny;

    //En inspector
    public float smooth = 0.05f;
    public Vector2 limitXY = Vector2.zero;

    //Dinámico
    public float camZ;

    private void Awake()
    {
        camZ = transform.position.z;
    }

    private void FixedUpdate()
    {
        

        if(target == null)
        {
            destiny = Vector3.zero;
        }
        else
        {
            destiny = target.transform.position;
            if(target.tag == "Bullet")
            {
                bool sleeping = target.GetComponent<Rigidbody>().IsSleeping();
                if (sleeping)
                {
                    target = null;
                    destiny = Vector3.zero;
                    CanionController.blocking = false;
                    return;
                }
            }
        }

        if (isLoock) destiny = vewtarget.transform.position;
        else if (target== null) destiny = Vector3.zero;

        destiny.x = Mathf.Max(limitXY.x, destiny.x);
        destiny.y = Mathf.Max(limitXY.y, destiny.y);
        destiny = Vector3.Lerp(transform.position, destiny, smooth);
        destiny.z = camZ;
        transform.position = destiny;
        Camera.main.orthographicSize = destiny.y + 5;

    }

    public void Vew()
    {
        isLoock = true;
    }
    public void VewOff()
    {
        isLoock = false;
    }
}
