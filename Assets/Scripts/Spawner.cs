using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float spawnTime;
    float timer;

    private void Start()
    {
        timer = spawnTime;
    }

    private void Update()
    {
        if(PhotonNetwork.IsMasterClient == false || PhotonNetwork.CurrentRoom.PlayerCount != 2)
        {
            return;
        }


        if(timer < 0)
        {
            Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            PhotonNetwork.Instantiate(enemy.name, spawnPos, Quaternion.identity);
            timer = spawnTime;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
