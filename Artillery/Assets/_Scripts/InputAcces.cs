using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAcces : MonoBehaviour
{
    PlayerControls _myInput;
    SceneM sceneManager;

    public bool inMenu;
    [SerializeField] GameObject menuPanel;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<SceneM>();

        _myInput = new PlayerControls();
        _myInput.Canon.Enable();
    }


    private void Update()
    {
        if (!inMenu)
        {
            if (_myInput.Canon.Start.WasPressedThisFrame())
            {
                sceneManager.GoToSelect();
            }

            if (_myInput.Canon.Menu.WasPressedThisFrame())
            {
                OpenMenu();
            }
        }
    }

    IEnumerator ReturnToMenu()
    {
        menuPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        inMenu = false;
    }
    void OpenMenu()
    {
        menuPanel.SetActive(true);
        inMenu = true;
    }
    public void CloseMenu()
    {
        StartCoroutine("ReturnToMenu");
    }
}
