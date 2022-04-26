using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerNames : MonoBehaviourPunCallbacks
{

    public TMP_Text textp1;
    public TMP_Text textp2;
    PhotonView view;

    void Start()
    {
        
    }

    void Update()
    {
        textp1.text = PhotonNetwork.PlayerList[0].NickName;
        textp2.text = PhotonNetwork.PlayerList[1].NickName;
    }
}
