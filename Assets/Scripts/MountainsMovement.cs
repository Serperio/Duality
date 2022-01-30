using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MountainsMovement : MonoBehaviour
{
    [SerializeField] private GameObject mountain;
    [SerializeField] private float speed;

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

        Debug.Log("me muevo");
        Vector3 position2 = instantiatedMountain2.transform.position;
        position2.x -= Time.deltaTime * speed;
        instantiatedMountain2.transform.position = position2;

        if (instantiatedMountain2.transform.position.x < -103)
        {
            Destroy(instantiatedMountain2);
            instantiatedMountain2 = Instantiate(mountain, new Vector3(166f, 5f, 10f), mountain.transform.rotation);
        }
    }
}
