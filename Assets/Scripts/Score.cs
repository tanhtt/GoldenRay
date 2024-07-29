using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    PhotonView view;
    public TMP_Text scoreText;
    public float score;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void AddScore()
    {
        view.RPC("AddScoreRPC", RpcTarget.All);
    }

    [PunRPC]
    void AddScoreRPC()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
