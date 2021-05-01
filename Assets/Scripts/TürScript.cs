using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TürScript : MonoBehaviour
{
    public GameObject Hero;
    public GameObject ZweiteTür;

    public GameObject Text;
    static public float CanTP = 1f;

    void Start()
    {
        Text.GetComponent<TextMesh>().color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Text.GetComponent<TextMesh>().color = Color.white;
        if ((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Captain") && Input.GetKey(KeyCode.R) && TürScript.CanTP == 1)
        {
            print("working");
            --CanTP;
            Invoke("CanTeleport", 3f);
            Hero = collision.gameObject;
            Teleport();
        }       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Text.GetComponent<TextMesh>().color = Color.clear;
    }
    public void Teleport()
    {
        var a = Hero.GetComponent<PlayerController>();
        ClientSend.PlayerMovement(new float[] { ZweiteTür.transform.position.x, ZweiteTür.transform.position.y, a.Speed }, true);
    }
    
    public void CanTeleport()
    {
        CanTP = 1f;
    }

}
