using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text shootsText;
    [SerializeField] TMP_Text targetText;
    [SerializeField] Image forceIndicator;
    [SerializeField] GameObject[] finishPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject tutoPanel;
    [SerializeField] Image stars;
    [SerializeField] Sprite[] starsPoints;
    [SerializeField] Image bullet;

    public bool inMenu;

    PlayerControls control;
    SceneM managerScene;

    public int targets;

    private void Awake()
    {
        finishPanel[0].SetActive(false);
        finishPanel[1].SetActive(false);
        finishPanel[2].SetActive(false);
    }

    private void Start()
    {
        GameManager.instance.RecetValues();
        managerScene = FindObjectOfType<SceneM>();

        control = new PlayerControls();
        control.Canon.Enable();

        if (GameManager.instance.firstTime) tutoPanel.SetActive(true);
        StartCoroutine("GameStart"); 
    }



    void Update()
    {
        if (GameManager.instance.firstTime == true)
        {
            if (control.Canon.Start.WasPerformedThisFrame())
            {
                PanelTuto();
            }
        }

        if (GameManager.instance.canShoot)
        {
            bullet.color = Color.white;
        }
        else bullet.color = Color.red;

        if (GameManager.instance.gameFinish == true)
        {
            if (control.Canon.Start.WasPerformedThisFrame())
            {
                managerScene.GoToSelect();
            }
        }

        if (!inMenu)
        {
            control.Canon.Menu.performed += ctx => OpenMenuPanel();
        }

        stars.sprite = starsPoints[GameManager.instance.stars[GameManager.instance.currentLevel]];

        shootsText.text = GameManager.instance._shoots.ToString();
        targetText.text = GameManager.instance.targetForWin.ToString();
        forceIndicator.fillAmount = GameManager.instance._bulletSpeed/25;

        if (GameManager.instance.targetForWin <= 0)
        {
            finishPanel[0].SetActive(true);
            finishPanel[1].SetActive(true);
            SetStars();
            GameManager.instance.gameFinish = true;
        }
        
        if (GameManager.instance._shoots <= 0 && GameManager.instance.targetForWin > 0)
        {
            finishPanel[0].SetActive(true);
            finishPanel[2].SetActive(true);
            GameManager.instance.gameFinish = true;
        }
    }

    public void PanelTuto()
    {
        tutoPanel.SetActive(false);
        GameManager.instance.firstTime = false;
        GameManager.instance.gameStart = true;
        GameManager.instance.canShoot = true;
    }

    public  void OpenMenuPanel()
    {
        menuPanel.SetActive(true);
        inMenu = true;
    }

    public void ClosePanel()
    {
        StartCoroutine("BackFromMenu");
    }

    IEnumerator BackFromMenu()
    {
        menuPanel.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        inMenu = false;
    }

    IEnumerator GameStart()
    {
        if(GameManager.instance.firstTime == false)
        {
            GameManager.instance.gameStart = true;
            yield return new WaitForSeconds(0.5f);
            GameManager.instance.canShoot = true;
        }
    }

    void SetStars()
    {
        if(GameManager.instance.currentLevel == 0)
        {
            if (GameManager.instance._shoots > 5) GameManager.instance.stars[0] = 3;
            if (GameManager.instance._shoots > 3 && GameManager.instance._shoots < 6) GameManager.instance.stars[0] = 2;
            if (GameManager.instance._shoots >=0 && GameManager.instance._shoots < 4 && GameManager.instance.targetForWin <= 0) GameManager.instance.stars[0] = 1;
        }
        if (GameManager.instance.currentLevel == 1)
        {
            if (GameManager.instance._shoots > 5) GameManager.instance.stars[1] = 3;
            if (GameManager.instance._shoots > 3 && GameManager.instance._shoots < 6) GameManager.instance.stars[1] = 2;
            if (GameManager.instance._shoots >= 0 && GameManager.instance._shoots < 4 && GameManager.instance.targetForWin <= 0) GameManager.instance.stars[1] = 1;
        }
        if (GameManager.instance.currentLevel == 2)
        {
            if (GameManager.instance._shoots > 4) GameManager.instance.stars[2] = 3;
            if (GameManager.instance._shoots > 2 && GameManager.instance._shoots < 5) GameManager.instance.stars[2] = 2;
            if (GameManager.instance._shoots >= 0 && GameManager.instance._shoots < 3 && GameManager.instance.targetForWin <= 0) GameManager.instance.stars[2] = 1;
        }
        if (GameManager.instance.currentLevel == 3)
        {
            if (GameManager.instance._shoots > 4) GameManager.instance.stars[3] = 3;
            if (GameManager.instance._shoots > 2 && GameManager.instance._shoots < 5) GameManager.instance.stars[3] = 2;
            if (GameManager.instance._shoots >= 0 && GameManager.instance._shoots < 3 && GameManager.instance.targetForWin <= 0) GameManager.instance.stars[3] = 1;
        }
        if (GameManager.instance.currentLevel == 4)
        {
            if (GameManager.instance._shoots > 4) GameManager.instance.stars[4] = 3;
            if (GameManager.instance._shoots > 2 && GameManager.instance._shoots < 5) GameManager.instance.stars[4] = 2;
            if (GameManager.instance._shoots >= 0 && GameManager.instance._shoots < 3 && GameManager.instance.targetForWin <= 0) GameManager.instance.stars[4] = 1;
        }
        if (GameManager.instance.currentLevel == 5)
        {
            if (GameManager.instance._shoots > 2) GameManager.instance.stars[5] = 3;
            if (GameManager.instance._shoots > 1 && GameManager.instance._shoots < 3) GameManager.instance.stars[5] = 2;
            if (GameManager.instance._shoots >= 0 && GameManager.instance._shoots < 2 && GameManager.instance.targetForWin <= 0) GameManager.instance.stars[5] = 1;
        }
    }
}
