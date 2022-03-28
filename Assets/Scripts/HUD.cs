using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{

    public TMP_Text txtP1points,
        txtP2points;
    public TMP_Text txtP1Count, 
        txtP2Count;
    public Timer deathP1,
        deathP2;

    private void Update()
    {
        txtP1Count.text = deathP1.stgTimer;
        txtP2Count.text = deathP2.stgTimer;
    }

    public void UpdateScore(int p1, int p2)
    {
        txtP1points.text = p1.ToString();
        txtP2points.text = p2.ToString();
    }

    public void DeathCountdown(int playerNum)
    {
        if(playerNum == 1)
        {
            deathP1.gameObject.SetActive(true);
        }
        else
        {
            deathP2.gameObject.SetActive(true);
        }
    }

}
