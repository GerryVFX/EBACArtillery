using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public void ResetScene()
    {
        if (GameManager.instance.currentLevel == 0) GoToPlayLV1();
        if (GameManager.instance.currentLevel == 1) GoToPlayLV2();
        if (GameManager.instance.currentLevel == 2) GoToPlayLV3();
        if (GameManager.instance.currentLevel == 3) GoToPlayLV4();
        if (GameManager.instance.currentLevel == 4) GoToPlayLV5();
        if (GameManager.instance.currentLevel == 5) GoToPlayLV6();
    }

    //SceneManager
    public void GoToMain()
    {
        SceneManager.LoadScene(0);
        GameManager.instance.inGame = false;
    }

    public void GoToSelect()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.inGame = false;
    }

    public void GoToPlayLV1()
    {
        GameManager.instance.gameFinish = false;
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = 0;
    }

    public void GoToPlayLV2()
    {
        GameManager.instance.gameFinish = false;
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = 1;
    }

    public void GoToPlayLV3()
    {
        GameManager.instance.gameFinish = false;
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = 2;
    }

    public void GoToPlayLV4()
    {
        GameManager.instance.gameFinish = false;
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = 3;
    }

    public void GoToPlayLV5()
    {
        GameManager.instance.gameFinish = false;
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = 4;
    }

    public void GoToPlayLV6()
    {
        GameManager.instance.gameFinish = false;
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = 5;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
