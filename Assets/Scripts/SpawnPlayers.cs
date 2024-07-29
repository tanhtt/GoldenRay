using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX,minY,maxX,maxY; // Boundary point of player
    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomSpawnPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(player.name, randomSpawnPos, Quaternion.identity);
    }

}
