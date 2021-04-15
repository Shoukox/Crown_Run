using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    public float diff = 0.45f;
    public int crownDelay = 3000;
    public bool crown = true;
    public int count = 0;

    private Timer _timer;
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y + diff);
    }
    public int UpdateCrown(bool value)
    {
        if (crown) crown = false; else return -1;
        count += 1;
        int current = count;
        _timer = new Timer(crownDelay);
        _timer.Elapsed += (s, e) =>
        {
            if (count == current) crown = value;
        };
        _timer.Start();
        return 0;
    }
}
