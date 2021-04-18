using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{   
    public static Vector2 leftCorner { get; set; }
    public static Vector2 rightCorner { get; set; }
    void Awake()
    {
        leftCorner = new Vector2(-40, 22);
        rightCorner = new Vector2(120, -85);
    }

}
