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
}
