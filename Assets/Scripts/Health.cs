using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public int health = 10;
    public TMP_Text healthDisplay;
    public GameObject gameOver;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void TakeDamage()
    {
        view.RPC("TakeDamageRPC", RpcTarget.All);
    }

    [PunRPC]
    void TakeDamageRPC()
    {
        health--;
        if(health <= 0)
        {
            gameOver.SetActive(true);
        }

        healthDisplay.text = health.ToString();
    }
}
