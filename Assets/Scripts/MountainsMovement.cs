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

    GameObject instantiatedMountain;
    GameObject instantiatedMountain2;

    private void Start()
    {
        instantiatedMountain = Instantiate(mountain, new Vector3(-30f, 5f, 10f), mountain.transform.rotation);
        instantiatedMountain2 = Instantiate(mountain, new Vector3(104f, 5f, 10f), mountain.transform.rotation);
    }

    private void Update()
    {
        Vector3 position = instantiatedMountain.transform.position;
        position.x -= Time.deltaTime * speed;
        instantiatedMountain.transform.position = position;

        if (instantiatedMountain.transform.position.x < -103)
        {
            Destroy(instantiatedMountain);
            instantiatedMountain = Instantiate(mountain, new Vector3(166f, 5f, 10f), mountain.transform.rotation);
        }

        Vector3 position2 = instantiatedMountain2.transform.position;
        position2.x -= Time.deltaTime * speed;
        instantiatedMountain2.transform.position = position2;

        if (instantiatedMountain2.transform.position.x < -103)
        {
            Destroy(instantiatedMountain2);
            instantiatedMountain2 = Instantiate(mountain, new Vector3(166f, 5f, 10f), mountain.transform.rotation);
        }

        if (changeColor)
        {
            if (rigthEye.IsClosed)
            {
                instantiatedMountain.gameObject.SetActive(true);
                instantiatedMountain2.gameObject.SetActive(true);
                instantiatedMountain.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f);
                instantiatedMountain2.GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f);
            }
            else if (leftEye.IsClosed)
            {
                instantiatedMountain.gameObject.SetActive(true);
                instantiatedMountain2.gameObject.SetActive(true);
                instantiatedMountain.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
                instantiatedMountain2.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 0f);
            }
            else
            {
                instantiatedMountain.gameObject.SetActive(true);
                instantiatedMountain2.gameObject.SetActive(true);
                instantiatedMountain.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 1f);
                instantiatedMountain2.GetComponent<SpriteRenderer>().color = new Color(1f, 0f, 1f);
            }

            if (leftEye.IsClosed && rigthEye.IsClosed)
            {
                instantiatedMountain.gameObject.SetActive(false);
                instantiatedMountain2.gameObject.SetActive(false);
            }
        }
    }
}
