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

    public Player player1;
    public Player player2;

    public void Start()
    {
        FindObjectOfType<AudioManager>().Play("Ambience");

        hud.UpdateScore(player1.data.score, player2.data.score);
        gameData.OnUpdateHUD.AddListener(UpdateHUD);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Restart();

        if(player1.enabled == false)
        {
            player1.enabled = true;
        }
    }

    public void Restart()
    {
        player1.Reset();
        player2.Reset();
    }

    public void UpdateHUD()
    {
        hud.UpdateScore(player1.data.score, player2.data.score);
    }
}