using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]InputAcces menuAcces;

    private void OnDisable()
    {
        menuAcces.inMenu = false;
    }
}
