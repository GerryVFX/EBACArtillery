using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    [SerializeField] Image[] starsLevel;
    [SerializeField] Sprite[] starsPoints;
    [SerializeField] int[] pointsInLevels;

    [SerializeField] GameObject[] lockLeveles;

    // Start is called before the first frame update
    void Start()
    {
        pointsInLevels[0] = GameManager.instance.pts[0];
        pointsInLevels[1] = GameManager.instance.pts[1];
        pointsInLevels[2] = GameManager.instance.pts[2];
        pointsInLevels[3] = GameManager.instance.pts[3];
        pointsInLevels[4] = GameManager.instance.pts[4];
        pointsInLevels[5] = GameManager.instance.pts[5];
    }

    // Update is called once per frame
    void Update()
    {
        starsLevel[0].sprite = starsPoints[pointsInLevels[0]];
        starsLevel[1].sprite = starsPoints[pointsInLevels[1]];
        starsLevel[2].sprite = starsPoints[pointsInLevels[2]];
        starsLevel[3].sprite = starsPoints[pointsInLevels[3]];
        starsLevel[4].sprite = starsPoints[pointsInLevels[4]];
        starsLevel[5].sprite = starsPoints[pointsInLevels[5]];

        if (GameManager.instance.totalPoints > 1) lockLeveles[0].SetActive(false);
        if (GameManager.instance.totalPoints > 3) lockLeveles[1].SetActive(false);
        if (GameManager.instance.totalPoints > 7) lockLeveles[2].SetActive(false);
        if (GameManager.instance.totalPoints > 9) lockLeveles[3].SetActive(false);
        if (GameManager.instance.totalPoints > 14) lockLeveles[4].SetActive(false);
    }
}
