using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingMusic : MonoBehaviour
{
    public AudioClip a;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic("A");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("m")){
            AudioManager.Instance.MuteMusic("A");
        }
        if (Input.GetKey("n"))
        {
            AudioManager.Instance.PlayMusic("A");
        }
    }
}
