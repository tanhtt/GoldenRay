using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    float resetSpeed;
    public float dashSpeed;
    public float dastTime;
    Animator anime;
    PhotonView view;
    Health playerHealth;

    LineRenderer line;
    public float minX,minY, maxX, maxY;

    public TMP_Text nickname;

    private void Start()
    {
        view = GetComponent<PhotonView>();
        anime = transform.Find("sprite").GetComponent<Animator>();
        playerHealth = FindObjectOfType<Health>();
        line = FindObjectOfType<LineRenderer>();
        resetSpeed = speed;

        if (view.IsMine)
        {
            nickname.text = PhotonNetwork.NickName;
        }
        else
        {
            nickname.text = view.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(view.IsMine)
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 moveAmount = speed * moveInput.normalized * Time.deltaTime;
            transform.position += (Vector3)moveAmount;

            Wrap();

            if(Input.GetKeyDown(KeyCode.Space) && moveInput != Vector2.zero)
            {
                StartCoroutine(Dash());
            }

            if(moveInput == Vector2.zero)
            {
                anime.SetBool("isRunning", false);
            }
            else
            {
                anime.SetBool("isRunning", true);
            }

            line.SetPosition(0, transform.position);
        }
        else
        {
            line.SetPosition(1, transform.position);
        }
    }

    IEnumerator Dash()
    {
        speed = dashSpeed;
        yield return new WaitForSeconds(dastTime);
        speed = resetSpeed;
    }

    void Wrap()
    {
        if(transform.position.x < minX)
        {
            transform.position = new Vector2(maxX, transform.position.y);
        }
        if (transform.position.x > maxX)
        {
            transform.position = new Vector2(minX, transform.position.y);
        }
        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (view.IsMine)
        {
            if (collision.CompareTag("Enemy"))
            {
                playerHealth.TakeDamage();
            }
        }
    }
}
