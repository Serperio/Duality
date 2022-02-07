using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTittle : MonoBehaviour
{
    float amount;
    [SerializeField] private float speed;
    private void Start()
    {
        amount  = transform.localRotation.eulerAngles.y;
    }
    private void Update()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
