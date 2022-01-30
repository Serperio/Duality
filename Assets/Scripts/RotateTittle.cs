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
        transform.Rotate(Vector3.up * 15 * Time.deltaTime);
    }
}
