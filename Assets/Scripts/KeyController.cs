using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private DoorController door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (AudioManager.Instance.gameObject != null)
            {
                print("audio");
                AudioManager.Instance.Play(3);
            }
            door.OpenDoor();
            Destroy(this.gameObject);
        }

    }
}
