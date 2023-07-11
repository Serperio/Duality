using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private bool isPressed = false;

    [SerializeField] private Sprite buttonPress;
    [SerializeField] private Sprite button;

    [SerializeField] private EyeController leftEye;
    [SerializeField] private EyeController rightEye;

    [SerializeField] private bool leftEyeOpen;
    [SerializeField] private bool rightEyeOpen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isPressed)
        {
            GetComponent<SpriteRenderer>().sprite = buttonPress;
            leftEye.IsClosed = leftEyeOpen;
            rightEye.IsClosed = rightEyeOpen;
            ObjectManager.instance.ManageObjects();
            isPressed = true;
        }
        
    }

    private void Update()
    {
        if (isPressed)
        {
            if (leftEye.IsClosed != leftEyeOpen || rightEye.IsClosed != rightEyeOpen)
            {
                ReleaseButton();
            }
        }
        
    }

    private void ReleaseButton()
    {
        GetComponent<SpriteRenderer>().sprite = button;
        isPressed = false;
    }
}
