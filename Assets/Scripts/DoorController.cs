using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;

public class DoorController : MonoBehaviour
{
    [SerializeField] private bool enabled;
    [SerializeField] private Sprite closedDoor;
    [SerializeField] private Sprite openDoor;
    [SerializeField] private GameObject explosionParticle;
    [SerializeField] private bool dialogue = false;
    [SerializeField] private bool isMedusa = false;
    [SerializeField] private Medusa medusa;
    [SerializeField] private bool isMessage = false;
    [SerializeField] private TMP_Text message;
    [SerializeField] private TestingDialogue finalDialogue;
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

        //print(enabled);
        if (enabled == true)
        {
            print("inicia encendido");
            GetComponent<SpriteRenderer>().sprite = openDoor;
        }
    }

    private void Update()
    {
        if (startGame)
        {           
            whiteNoise.DOFade(0, 1).OnPlay(() => startGame = false);
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(.3f).Append(DOTween.To(() => temp, x => temp = x, 1, 0.2f).OnPlay(() =>
            {
                //AudioManager.Instance.PlayMusic("A");
                //AudioManager.Instance.PlayMusic("B");
                PP.SetActive(true);
                if (dialogue && PlayerPrefs.GetInt("Dead") == 0)
                {
                    dialogueManager.StartDialogue();
                }
                else
                {
                    dialogueManager.ActiveEnemies();
                }
            }));
        }
    }

    public void WhiteNoiseAnim()
    {
        PP.SetActive(false);

        whiteNoise.DOFade(1f, .5f).OnComplete(() =>
        {
            PP.SetActive(true);
            DOTween.Sequence().AppendInterval(0.5f).Append(whiteNoise.DOFade(0, 1).OnComplete(() => 
            {
                if (isMessage)
                {
                    DOTween.Sequence().AppendInterval(1f).AppendCallback(() =>
                    {
                        message.DOFade(1f, 0.5f).OnComplete(() =>
                        {
                            DOTween.Sequence().AppendInterval(2f).Append(message.DOFade(0f, 0.5f));
                        });
                    });
                }
            }));
        });
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enabled && SceneManager.GetActiveScene().name != "L 29")
            {
                PlayerPrefs.SetInt("Dead", 0);
                if (isMedusa) medusa.KillMedusa();
                PP.SetActive(false);
                whiteNoise.DOFade(1f, 1f).OnPlay(()=> {
                    if (AudioManager.Instance.gameObject != null)
                    {
                        print("audio");
                        AudioManager.Instance.PlaySFX(1);
                    }
                }).OnComplete(() =>
                {
                    string levelName = SceneManager.GetActiveScene().name;
                    string index = levelName.Split(' ')[1];
                    Debug.Log(index);
                    SceneManager.LoadScene("L " + (int.Parse(index) + 1));
                });
            }
            else
            {
                PlayerPrefs.SetInt("Dead", 0);
                if (isMedusa) medusa.KillMedusa();
                if (SceneManager.GetActiveScene().name == "L 29")
                {
                    finalDialogue.StartDialogue();
                }
            }
                //print("pasaste");
            
        }
            
    }
    public void OpenDoor()
    {
        explosionParticle.SetActive(true);
        Destroy(explosionParticle, 1);
        enabled = true;
        GetComponent<SpriteRenderer>().sprite = openDoor;
    }

    public Medusa Medusa { get { return medusa; } }
}
