using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    private float camX;

    void Update()
    {
        camX = target.position.x;
        if (camX < 0) camX = 0;
        Vector3 newPos = new Vector3(camX, -1.77f,-54.61f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
