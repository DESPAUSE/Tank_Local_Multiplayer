using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    Player player;
    float time;
    public string stgTimer;

    private void Start()
    {
        time = 3;
        player = GetComponentInParent<Player>();
    }

    private void Reset()
    {
        this.gameObject.SetActive(false);
        player.Reset();
        time = 3;
        stgTimer = string.Format("{0:00}", time);
    }

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            Reset();
        }
        stgTimer = string.Format("{0:00}", time);
    }
}
