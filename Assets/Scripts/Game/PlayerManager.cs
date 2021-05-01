using UnityEngine;
using System.Timers;

public class PlayerManager : MonoBehaviour
{
    public string username;
    public int id;

    private void Update()
    {
        NickNameView();
    }
    void NickNameView()
    {
        GetComponentInChildren<TextMesh>().text = username;
    }
}

