using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Boost : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isWorking = true;
    public int delay = 5000;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && isWorking)
        {
            isWorking = false;
            var hero = collision.gameObject.GetComponent<Hero>();
            hero.Speed *= 1.5f;
            Timer timer = new Timer(delay);
            timer.Elapsed += (s, e) => hero.Speed = hero._defaultSpeed;
            timer.Start();
            Destroy(gameObject);
        }
    }
}
