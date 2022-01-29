using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;
    [SerializeField] private EyeController leftEye;
    [SerializeField] private EyeController rightEye;

    [SerializeField] private GameObject NoneContainer;
    [SerializeField] private GameObject LeftContainer;
    [SerializeField] private GameObject RightContainer;
    [SerializeField] private GameObject BothContainer;
    private void Awake()
    {
        instance = this;   
    }
    private void Start()
    {
        ManageObjects();
    }
    public void ManageObjects()
    {
        TurnObjects(NoneContainer, false);
        TurnObjects(LeftContainer, false);
        TurnObjects(RightContainer, false);
        TurnObjects(BothContainer, false);
        //print("el ojo izquierdo esta cerrado? " + leftEye.IsClosed);
        //print("el ojo derecho esta cerrado? " + rightEye.IsClosed);
        if (leftEye.IsClosed)
        {
            if (rightEye.IsClosed)
            {
                TurnObjects(NoneContainer, true);
            }
            else
            {
                TurnObjects(RightContainer, true);
            }
        }
        else
        {
            if (rightEye.IsClosed)
            {
                TurnObjects(LeftContainer, true);
            }
            else
            {
                TurnObjects(LeftContainer, true);
                TurnObjects(RightContainer, true);
                TurnObjects(BothContainer, true);
            }
        }
        

        
        


    }

    private void TurnObjects(GameObject container, bool state)
    {
        for(int i = 0; i < container.transform.childCount; i++)
        {
            container.transform.GetChild(i).gameObject.SetActive(state);
        }
    }
}
