using UnityEngine;
using System.Timers;

public class Hero : MonoBehaviour
{
    public string NickName = "PaFisU";
    public float _defaultSpeed = 0.2f;
    public float Speed = 0.2f;
    public float DashBar = 1f;

    private bool _isGrounded = false;
    private SpriteRenderer _sr;


    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        Movement();
        Inst();
        Dash();
    }
    private void Update()
    {
        NickNameView();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, true);
        if (collision.gameObject.tag == "Player" && gameObject.tag == "Captain")
        {
            var krone = transform.Find("crown");
            if(krone.GetComponent<Crown>().UpdateCrown(true) == -1) return;
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
    }



    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, false);
    }

    void IsGroundedUpdate(Collision2D collision, bool isGround)
    {
        if (collision.gameObject.tag == "Ground")
            _isGrounded = isGround;
    }

    void Movement()
    {
        float ox = Input.GetAxis("Horizontal");
        float oy = Input.GetAxis("Vertical");
        _sr.flipX = true ? ox < 0 : false;
        Vector2 forcingTo = new Vector2(ox, oy);
        transform.Translate(forcingTo * Speed);
        if (ox != 0f && oy != 0f) print($"{ox} {oy} {Speed}");
        //_rb.AddForce(forcingTo * Speed);
    }

    void Inst()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Instantiate(transform, new Vector3(10f, 10f, 0f), Quaternion.identity);
        }
    }

    void NickNameView()
    {
        GetComponentInChildren<TextMesh>().text = NickName;
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

}

