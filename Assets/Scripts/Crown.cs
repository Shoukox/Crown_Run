using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crown : MonoBehaviour
{
    // Start is called before the first frame update
    public float diff = 0.45f;
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.parent.position.x, transform.parent.position.y + diff);
    }
}
