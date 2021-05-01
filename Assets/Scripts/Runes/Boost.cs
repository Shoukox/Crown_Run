using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Boost : MonoBehaviour
{
    // Start is called before the first frame update

    public static int boostrunesCount = 1;
    public int delay = 5000;
    public List<string> allowed = new List<string>() { "Player", "Captain" };

    private void Start()
    {
        for (int i = boostrunesCount; i<10; i++)
        {
            SpawnRune();
        }
    }

    public void SpawnRune()
    {
        if (boostrunesCount < 10)
        {
            float rnd1 = Random.Range(Map.leftCorner.x, Map.rightCorner.x);
            float rnd2 = Random.Range(Map.rightCorner.y, Map.leftCorner.y);
            Instantiate(transform, new Vector2(rnd1, rnd2), Quaternion.identity);
            boostrunesCount += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(allowed.Contains(collision.gameObject.tag))
        {
            var hero = collision.gameObject.GetComponent<PlayerController>();
            hero.boostUsed += 1;
            int current = hero.boostUsed;
            hero.Speed = hero._defaultSpeed * 1.5f;
            Timer timer = new Timer(delay);
            timer.Elapsed += (s, e) => { if (hero.boostUsed == current) hero.Speed = hero._defaultSpeed; };
            timer.Start();
            SpawnRune();
            Destroy(gameObject);
            boostrunesCount -= 1;
        }
    }
}
