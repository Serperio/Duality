using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    
    [SerializeField] private GameObject particle;
    private bool isFirstTime = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isFirstTime)
        {
            

            isFirstTime = false;
            particle.SetActive(true);
            this.gameObject.GetComponent<RotateTittle>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            
        }

    }
}
