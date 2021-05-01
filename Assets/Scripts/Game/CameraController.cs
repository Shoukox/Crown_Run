using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float CameraSpeed = 2f;
    public float linkGrenze;
    public float rechtGrenze;
    public float untenGrenze;
    public float obenGrenze;

    public void KameraStop()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, linkGrenze, rechtGrenze),Mathf.Clamp(transform.position.y, obenGrenze, untenGrenze),transform.position.z);
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.transform.position.x, target.transform.position.y, -10f), Time.deltaTime * CameraSpeed);
        KameraStop();
    }
}
