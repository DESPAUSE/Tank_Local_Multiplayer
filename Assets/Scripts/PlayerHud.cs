using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerHud : MonoBehaviourPunCallbacks
{
    public TMP_Text textNick;
    public PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();   
    }

    public void SetHud(string nick) 
    {
        textNick.text = nick;
    }
}
