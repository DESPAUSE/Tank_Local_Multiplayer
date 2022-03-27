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

    public GameData_SO gameData;
    public HUD hud;

    public GameObject player1;
    public GameObject player2;

    public void Start()
    {
        hud.UpdateScore(player1.GetComponent<Player>().data.score, player2.GetComponent<Player>().data.score);
        gameData.OnUpdateHUD.AddListener(UpdateHUD);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Restart();
    }

    public void Restart()
    {
        player1.GetComponent<Player>().Reset();
        player2.GetComponent<Player>().Reset();
    }

    public void UpdateHUD()
    {
        hud.UpdateScore(player1.GetComponent<Player>().data.score, player2.GetComponent<Player>().data.score);
    }
}