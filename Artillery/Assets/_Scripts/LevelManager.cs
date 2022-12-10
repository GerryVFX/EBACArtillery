using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Transform levelSpawn;

    private void Start()
    {
        if (GameManager.instance.currentLevel == 0) Instantiate(GameManager.instance.levels[0], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 1) Instantiate(GameManager.instance.levels[1], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 2) Instantiate(GameManager.instance.levels[2], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 3) Instantiate(GameManager.instance.levels[3], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 4) Instantiate(GameManager.instance.levels[4], levelSpawn.position, transform.rotation);
        if (GameManager.instance.currentLevel == 5) Instantiate(GameManager.instance.levels[5], levelSpawn.position, transform.rotation);
    }
}
