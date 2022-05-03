using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerHud : MonoBehaviourPunCallbacks
{
    string nickString;
    public TMP_Text textNick;
    PhotonView view;

    public void SetHud() 
    {
        nickString = view.Owner.NickName;
        textNick.text = nickString;
        view = GetComponent<PhotonView>();
    }
}
