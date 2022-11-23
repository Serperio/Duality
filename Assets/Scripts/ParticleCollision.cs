using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem part;
    [SerializeField] private DoorController door;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (AudioManager.Instance.gameObject != null)
        {

            print("audio");
            AudioManager.Instance.Play(3);
        }

        door.OpenDoor();

        print("puerta");
    }
}
