using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medusa : MonoBehaviour
{
    [SerializeField] private EyeController rightEye;
    [SerializeField] private EyeController leftEye;

    int randomNumber;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0, 5000);

        if (randomNumber == 300)
        {
            Debug.Log("Entre");
        }
    }

    private void CheckEyes()
    {
        if (!rightEye.IsClosed || !leftEye.IsClosed)
        {
            Debug.Log("moriste");
        }
    }
}
