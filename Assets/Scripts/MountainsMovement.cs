using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MountainsMovement : MonoBehaviour
{
    [SerializeField] private GameObject mountain;
    [SerializeField] private float speed;

    [SerializeField] private EyeController rigthEye;
    [SerializeField] private EyeController leftEye;

    [SerializeField] private bool changeColor = false;

    [SerializeField] private Camera camera;
    [SerializeField] private SpriteRenderer tv;
    [SerializeField] private Transform background;

    GameObject instantiatedMountain;
    GameObject instantiatedMountain2;
    GameObject instantiatedMountain3;
    Vector2 mountainSize;

    bool firstMountain = true;
    bool secondMountain = false;
    bool thridMountain = false;

    private void Start()
    {
        instantiatedMountain = Instantiate(mountain, new Vector3(0f, 4.65f, 10f), mountain.transform.rotation, background);
        mountainSize = instantiatedMountain.GetComponent<SpriteRenderer>().bounds.size;
    }

    private void Update()
    {
        if (instantiatedMountain != null)
        {
            Vector3 position = instantiatedMountain.transform.position;
            position.x -= Time.deltaTime * speed;
            instantiatedMountain.transform.position = position;

            if (instantiatedMountain.transform.position.x + (mountainSize.x / 2) < camera.transform.position.x - (tv.bounds.size.x / 2))
            {
                firstMountain = false;
                Destroy(instantiatedMountain);
            }

            if (instantiatedMountain.transform.position.x + (mountainSize.x / 2) < camera.transform.position.x + (tv.bounds.size.x / 2) && !secondMountain)
            {
                secondMountain = true;
                float pos = instantiatedMountain.transform.position.x + mountainSize.x;
                instantiatedMountain2 = Instantiate(mountain, new Vector3(pos, 4.65f, 10f), mountain.transform.rotation, background);
            }
        }

        if (instantiatedMountain2 != null)
        {
            Vector3 position = instantiatedMountain2.transform.position;
            position.x -= Time.deltaTime * speed;
            instantiatedMountain2.transform.position = position;

            if (instantiatedMountain2.transform.position.x + (mountainSize.x / 2) < camera.transform.position.x - (tv.bounds.size.x / 2))
            {
                secondMountain = false;
                Destroy(instantiatedMountain2);
            }

            if (instantiatedMountain2.transform.position.x + (mountainSize.x / 2) < camera.transform.position.x + (tv.bounds.size.x / 2) && !thridMountain)
            {
                thridMountain = true;
                float pos = instantiatedMountain2.transform.position.x + mountainSize.x;
                instantiatedMountain3 = Instantiate(mountain, new Vector3(pos, 4.65f, 10f), mountain.transform.rotation, background);
            }
        }

        if (instantiatedMountain3 != null)
        {
            Vector3 position = instantiatedMountain3.transform.position;
            position.x -= Time.deltaTime * speed;
            instantiatedMountain3.transform.position = position;

            if (instantiatedMountain3.transform.position.x + (mountainSize.x / 2) < camera.transform.position.x - (tv.bounds.size.x / 2))
            {
                thridMountain = false;
                Destroy(instantiatedMountain3);
            }

            if (instantiatedMountain3.transform.position.x + (mountainSize.x / 2) < camera.transform.position.x + (tv.bounds.size.x / 2) && !firstMountain)
            {
                firstMountain = true;
                float pos = instantiatedMountain3.transform.position.x + mountainSize.x;
                instantiatedMountain = Instantiate(mountain, new Vector3(pos, 4.65f, 10f), mountain.transform.rotation);
            }
        }


        //Vector3 position2 = instantiatedMountain2.transform.position;
        //position2.x -= Time.deltaTime * speed;
        //instantiatedMountain2.transform.position = position2;

        //if (instantiatedMountain2.transform.position.x < -103)
        //{
        //    Destroy(instantiatedMountain2);
        //    instantiatedMountain2 = Instantiate(mountain, new Vector3(166f, 4.65f, 10f), mountain.transform.rotation);
        //}

        if (changeColor)
        {
            if (instantiatedMountain != null)
                ChageMountainColor(instantiatedMountain);

            if (instantiatedMountain2 != null)
                ChageMountainColor(instantiatedMountain2);

            if (instantiatedMountain3 != null)
                ChageMountainColor(instantiatedMountain3);
        }
    }


    private void ChageMountainColor (GameObject mountain)
    {
        mountain.gameObject.SetActive(true);   

        if (rigthEye.IsClosed)
        {
            mountain.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f);
        }
        else if (leftEye.IsClosed)
        {
            mountain.GetComponent<SpriteRenderer>().color = new Color(1f, 0.37f, 0f);
        }
        else
        {
            mountain.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 1f);
        }

        if (leftEye.IsClosed && rigthEye.IsClosed)
        {
            mountain.gameObject.SetActive(false);
        }
    }
}
