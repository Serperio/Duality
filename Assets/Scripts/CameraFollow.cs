using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public Transform target;
    [SerializeField]
    private bool isTheLevel;
    private float camX;
    private float camY;

    void Update()
    {
        camX = target.position.x;

        if (isTheLevel)
            camY = target.position.y;

        if (camX < 0) camX = 0;
        if (camY > -21f) camY = -1.77f;

        if (camY != -1.77f) FollowSpeed = 20f;

        Vector3 newPos = new Vector3(camX, camY, -54.61f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed*Time.deltaTime);
    }
}
