using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public static GameObject target;
    public GameObject vewtarget;
    public bool isLoock;
    Vector3 destiny;

    PlayerControls input;
    UIManager uiManager;

    //En inspector
    public float smooth = 0.05f;
    public Vector2 limitXY = Vector2.zero;

    //Dinámico
    public float camZ;
    public bool returnCannon;
   
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();

        camZ = transform.position.z;

        input = new PlayerControls();
        input.Canon.Enable();
        input.Canon.SecondAction.performed += ctx => Vew();
        input.Canon.SecondAction.canceled += ctx => VewOff();
    }

    private void FixedUpdate()
    {
        if (returnCannon) StartCoroutine("BackCannon");

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

    IEnumerator BackCannon()
    {
        returnCannon = false;
        yield return new WaitForSeconds(2f);
        GameManager.instance.canShoot = true;
    }

    public void Vew()
    {
        if (uiManager.inMenu == false && GameManager.instance.gameStart == true && GameManager.instance.gameFinish == false)
        {
            isLoock = true;
        }
        
    }
    public void VewOff()
    {
        if (uiManager.inMenu == false && GameManager.instance.gameStart == true && GameManager.instance.gameFinish == false)
        {
            isLoock = false;
        }
    }
}
