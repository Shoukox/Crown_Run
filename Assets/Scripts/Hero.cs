using UnityEngine;
using System.Timers;

public class Hero : MonoBehaviour
{
    public float _defaultSpeed = 0.2f;
    public float Speed = 0.2f;
    public Transform prefab;

    private bool _isGrounded = false;

    private void FixedUpdate()
    {
        Movement();
        Inst();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGroundedUpdate(collision, true);
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
        Vector2 forcingTo = new Vector2(ox, oy);
        transform.Translate(forcingTo * Speed);
        if (ox != 0f && oy != 0f) print($"{ox} {oy} {Speed}");
        //_rb.AddForce(forcingTo * Speed);
    }

    void Inst()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Instantiate(prefab, new Vector3(10f, 10f, 0f), Quaternion.identity);
        }
    }

    void Boost(float addSpeed, int delay)
    {
        Speed *= 1.5f;
        Timer timer = new Timer(delay);
        timer.Elapsed += (s, e) => Speed = _defaultSpeed;
        timer.Start();
    }

}

