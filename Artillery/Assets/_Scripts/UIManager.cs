using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text shootsText;

    void Update()
    {
        shootsText.text = GameManager.instance._shoots.ToString();
    }
}
