using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour
{
    [SerializeField] private bool isLeft;
    [SerializeField] public GameObject openEye;
    [SerializeField] private bool isClosed = false;
    
    private string buttonName = "Fire2";
    

    public bool IsClosed { get => isClosed; set => isClosed = value; }

    private void Start()
    {
        if (isLeft)
        {
            buttonName = "Fire1";
        }
    }
    void Update()
    {
        if (Input.GetButton(buttonName))
        {
            if (!IsClosed)
            {
                IsClosed = true;
                ObjectManager.instance.ManageObjects();
            }
        }
        else
        {
            if (IsClosed)
            {
                IsClosed = false;
                ObjectManager.instance.ManageObjects();
            }
        }

    }
}
