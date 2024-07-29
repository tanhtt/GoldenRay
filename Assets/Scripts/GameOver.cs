using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public TMP_Text scoreDisplay;
    public GameObject restartButton;
    public GameObject waitingText;

    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        scoreDisplay.text = FindObjectOfType<Score>().score.ToString();
        if (PhotonNetwork.IsMasterClient == false)
        {
            restartButton.SetActive(false);
            waitingText.SetActive(true);
        }
    }

    public void Restart()
    {
        view.RPC("RestartRPC", RpcTarget.All);
    }

    [PunRPC]
    void RestartRPC()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
