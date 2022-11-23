using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    private PlatformEffector2D effector;
    private float waitTime;
    [SerializeField] private float maxTime;
    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            waitTime = maxTime;
            effector.rotationalOffset = 0f;
        }
        if(Input.GetAxis("Vertical") < 0)
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = maxTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
