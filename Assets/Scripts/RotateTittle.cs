using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTittle : MonoBehaviour
{
    float amount;
    private void Start()
    {
        amount  = transform.localRotation.eulerAngles.y;
    }
    private void Update()
    {
        amount+=Time.deltaTime/10;
        print(transform.localRotation.eulerAngles.y);
        if (transform.localRotation.eulerAngles.y > 90 && transform.localRotation.eulerAngles.y < 270)
        {
            amount = 270;
            print("more");
        }
        if (transform.localRotation.eulerAngles.y > 360) amount = 0;
        transform.Rotate(transform.rotation.x, amount, transform.rotation.z, Space.World);
    }
}
