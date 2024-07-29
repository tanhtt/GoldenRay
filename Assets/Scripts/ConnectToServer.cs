using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        StartCoroutine(WaitForLoadingScene());
    }

    IEnumerator WaitForLoadingScene()
    {
        yield return new WaitForSeconds(4);
        LevelLoader.Instance.LoadLevel("MainScene");
    }
}
