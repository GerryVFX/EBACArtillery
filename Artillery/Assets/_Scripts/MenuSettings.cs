using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [SerializeField] Slider silerBGMusic;
    [SerializeField] Slider silerFXMusic;

    // Start is called before the first frame update
    void Start()
    {
        silerBGMusic.value = GameManager.instance.bgVolume;
        silerFXMusic.value = GameManager.instance.fxVolume;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager.instance.bgVolume = silerBGMusic.value;
        GameManager.instance.fxVolume = silerFXMusic.value;
    }
}
