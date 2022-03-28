using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text txtP1points, txtP2points;

    public void UpdateScore(int p1, int p2)
    {
        txtP1points.text = p1.ToString();
        txtP2points.text = p2.ToString();
    }

    
}
