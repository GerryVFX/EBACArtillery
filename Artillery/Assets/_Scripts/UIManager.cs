using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text shootsText;
    [SerializeField] TMP_Text targetText;
    [SerializeField] Image forceIndicator;
    [SerializeField] GameObject[] finishPanel;

    public int targets;

    private void Start()
    {
        finishPanel[0].SetActive(false);
        finishPanel[1].SetActive(false);
        finishPanel[2].SetActive(false);
    }



    void Update()
    {
        shootsText.text = GameManager.instance._shoots.ToString();
        targetText.text = GameManager.instance.targetForWin.ToString();
        forceIndicator.fillAmount = GameManager.instance._bulletSpeed/25;

        if (GameManager.instance.targetForWin <= 0)
        {
            finishPanel[0].SetActive(true);
            finishPanel[1].SetActive(true);
        }
        
        if (GameManager.instance._shoots <= 0 && GameManager.instance.targetForWin > 0)
        {
            finishPanel[0].SetActive(true);
            finishPanel[2].SetActive(true);
        }
    }
}
