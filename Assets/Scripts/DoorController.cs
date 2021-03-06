using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool enabled;
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;
    [SerializeField] private bool dialogue = false;
    public SpriteRenderer whiteNoise;
    public GameObject PP;

    private float temp;
    private TestingDialogue dialogueManager;
    private bool startGame;

    private void Start()
    {
        startGame = transform;
        dialogueManager = gameObject.GetComponent<TestingDialogue>();
        PP.SetActive(false);
        if (dialogue)
        {
            dialogueManager.StratDialogue();
        }
        
        //print(enabled);
        if(enabled == true)
        {
            print("inicia encendido");
            GetComponent<SpriteRenderer>().sprite = openDoor;
        }
    }

    private void Update()
    {
        if (!dialogueManager.GetIsTalking() && startGame)
        {
            whiteNoise.DOFade(0, 1).OnPlay(() => startGame = false);
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(.3f).Append(DOTween.To(() => temp, x => temp = x, 1, 0.2f).OnPlay(() => 
            {
                //AudioManager.Instance.PlayMusic("A");
                //AudioManager.Instance.PlayMusic("B");
                PP.SetActive(true); 
            }));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enabled)
            {
                PP.SetActive(false);
                whiteNoise.DOFade(1f, 1f).OnPlay(()=> {
                    if (AudioManager.Instance.gameObject != null)
                    {
                        print("audio");
                        AudioManager.Instance.Play(1);
                    }
                }).OnComplete(() =>
                {
                    string levelName = SceneManager.GetActiveScene().name;
                    string index = levelName.Split(' ')[1];
                    if(int.Parse(index) + 1 == 14)
                    {
                        SceneManager.LoadScene("Tittle Scene");
                    }
                    else
                    {
                        SceneManager.LoadScene("Level " + (int.Parse(index) + 1));
                    }
                    
                });
            }
                //print("pasaste");
            
        }
            
    }
    public void OpenDoor()
    {
        enabled = true;
        GetComponent<SpriteRenderer>().sprite = openDoor;
    }
}
