using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float _defaultSpeed = 2.5f;
    public float Speed = 2.5f;
    public float DashBar = 1f;
    public int boostUsed = 0;

    public bool isHost = false;
    public bool isCollision = false;

    private void FixedUpdate()
    {
        SendInputToServer();
        Dash();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Captain")
        {
            var krone = transform.Find("crown");
            if (krone.GetComponent<Crown>().UpdateCrown(true) == -1) return;
            collision.gameObject.tag = "Captain";
            gameObject.tag = "Player";
            krone.SetParent(collision.transform);
        }
        else if (collision.gameObject.tag == "Captain" && gameObject.tag == "Player")
        {
            var krone = collision.transform.Find("crown");
            if (krone.GetComponent<Crown>().UpdateCrown(true) == -1) return;
            collision.gameObject.tag = "Player";
            gameObject.tag = "Captain";
            krone.SetParent(transform);
        }
        else if (collision.gameObject.tag != "Captain" && collision.gameObject.tag != "Player")
        {
            isCollision = true;
        }
        print($"{collision.gameObject.name}");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isCollision = false;
    }

    void Dash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && DashBar >= 0)
        {
            Speed = _defaultSpeed * 1.25f;
            DashBar -= 0.01f;
        }
        else if (DashBar != 1f)
        {
            DashBar += 0.01f;
            Speed = _defaultSpeed;
        }
    }

    void SendInputToServer()
    {
        float[] inputs = new float[]
        {
            Input.GetAxis("Horizontal") * Speed,
            Input.GetAxis("Vertical") * Speed,
            Speed  
        };
        if (!isCollision)
        {
            ClientSend.PlayerMovement(inputs);
        }
    }
}
