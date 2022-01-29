using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool enabled;
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;

    private void Start()
    {
        print(enabled);
        if(enabled == true)
        {
            print("inicia encendido");
            GetComponent<SpriteRenderer>().sprite = openDoor;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enabled) print("pasaste");
        }
            
    }
    public void OpenDoor()
    {
        enabled = true;
        GetComponent<SpriteRenderer>().sprite = openDoor;
    }
}
