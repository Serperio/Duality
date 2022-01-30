using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.Rendering;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool enabled;
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;
    [SerializeField] private SpriteRenderer whiteNoise;
    [SerializeField]  private GameObject PP;

    private void Start()
    {
        PP.SetActive(false);
        whiteNoise.DOFade(0, 1).OnComplete(() => PP.SetActive(true));
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
            PP.SetActive(false);
            whiteNoise.DOFade(1f, 1f).OnComplete(() => 
            {
                whiteNoise.DOFade(0f, 1f).OnComplete(() => PP.SetActive(true));
            });
        }
            
    }
    public void OpenDoor()
    {
        enabled = true;
        GetComponent<SpriteRenderer>().sprite = openDoor;
    }
}
