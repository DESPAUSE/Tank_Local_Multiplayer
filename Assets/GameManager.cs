using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager GM;


    private void Awake()
    {
        if (GM == null)
        {
            GM = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    public GameObject player1;
    public GameObject player2;
    Vector3 p1pos;
    Vector3 p2pos;

    public void Start()
    {
        p1pos = player1.transform.position;
        p2pos = player2.transform.position;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Restart();
    }

    public void Restart()
    {
        player1.GetComponent<Player>().enabled = true;
        player2.GetComponent<Player>().enabled = true;
        player1.transform.position = new Vector3(p1pos.x, p1pos.y, p1pos.z);
        player2.transform.position = new Vector3(p2pos.x, p2pos.y, p2pos.z);
    }
}