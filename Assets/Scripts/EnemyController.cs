using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private PlayerController[] players;
    private PlayerController nearest;
    public float speed;

    Score _score;

    private void Start()
    {
        players = FindObjectsOfType<PlayerController>();
        _score = FindObjectOfType<Score>();
    }

    private void Update()
    {
        float distance1 = Vector2.Distance(transform.position, players[0].transform.position);
        float distance2 = Vector2.Distance(transform.position, players[1].transform.position);

        if(distance1 < distance2 )
        {
            nearest = players[0];
        }
        else
        {
            nearest = players[1];
        }

        if(nearest != null )
        {
            transform.position = Vector2.MoveTowards(transform.position, nearest.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (collision.CompareTag("GoldenRay"))
            {
                _score.AddScore();
                PhotonNetwork.Destroy(this.gameObject);
            }
        }
    }
}
