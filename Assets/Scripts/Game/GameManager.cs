using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static Dictionary<int, PlayerManager> players = new Dictionary<int, PlayerManager>();

    public GameObject playerPrefab;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists... destroying useless materials");
            Destroy(this);
        }
    }

    public void SpawnPlayer(int id, string username, Vector2 position, Quaternion rotation)
    {
        GameObject player = Instantiate(playerPrefab, position, rotation);
        player.GetComponent<PlayerManager>().id = id;
        player.GetComponent<PlayerManager>().username = username;

        if (id == Client.instance.myId)
        {
            var camera = GameObject.Find("Main Camera").GetComponent<CameraController>();
            camera.target = player;
            camera.enabled = true;
        }

        players.Add(id, player.GetComponent<PlayerManager>());
    }
}
