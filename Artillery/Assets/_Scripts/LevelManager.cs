using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    [SerializeField] Transform levelSpawn;

    private void Start()
    {
        if (GameManager.instance.currentLevel == 0) Instantiate(levels[0], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 1) Instantiate(levels[1], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 2) Instantiate(levels[2], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 3) Instantiate(levels[3], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 4) Instantiate(levels[4], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 5) Instantiate(levels[5], levelSpawn.position, transform.rotation);
    }
}
