using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public void ResetScenen()
    {
        GameManager.instance._shoots = 5;
        SceneManager.LoadScene(0);
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
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = "Level1";
    }

    public void GoToPlayLV2()
    {
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = "Level2";
    }

    public void GoToPlayLV3()
    {
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = "Level3";
    }

    public void GoToPlayLV4()
    {
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = "Level4";
    }

    public void GoToPlayLV5()
    {
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = "Level5";
    }

    public void GoToPlayLV6()
    {
        SceneManager.LoadScene(2);
        GameManager.instance.inGame = true;
        GameManager.instance.currentLevel = "Level6";
    }
}
