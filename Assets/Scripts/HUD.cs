using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text txtP1points,
        txtP2points;
    public TMP_Text txtCount;
    public Timer death;

    private void Update()
    {
        txtCount.text = death.stgTimer;
    }

    public void UpdateScore(int p1, int p2)
    {
        txtP1points.text = p1.ToString();
        txtP2points.text = p2.ToString();
    }

    public void DeathCountdown(int playerNum)
    {
        if (playerNum == 1)
        {
            death.player = playerNum;
            death.gameObject.SetActive(true);
        }
        if(playerNum == 2)
        {
            death.player = playerNum;
            death.gameObject.SetActive(true);
        }

    }
}
