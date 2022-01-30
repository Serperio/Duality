using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TestingDialogue : MonoBehaviour
{
    //public DialogueManager dialogueManager;
    public TMP_Text playerText;
    public GameObject playerTextContianer;
    public Image playerImage;
    public TMP_Text npcText;
    public GameObject npcTextContianer;
    public Image npcImage;
    public string[] dialogos;

    public List<Sprite> playerImages;

    bool isTalking;
    int i;
    public PlayerAnimationController playerani;
    public PlayerMovement playermov;
    public Rigidbody2D rigidbody2D;
    public Animator anim;
    public EyeController eyeder;
    public EyeController eyeizq;
    public bool areEyes;

    private bool isTextAnimated = false;
    private Coroutine textAnimation;
    private string currentSpeaker;
    private Sprite currentSpearkerImage;

    // Start is called before the first frame update
    void Start()
    {
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            if (Input.GetKeyDown("x"))
            {
                if (!isTextAnimated)
                {
                    if (currentSpeaker == "Player")
                    {
                        playerText.text = "";
                    }
                    else
                    {
                        npcText.text = "";
                    }
                    i += 1;

                    if (i > dialogos.Length - 1)
                    {
                        isTalking = false;
                        playerani.enabled = true;
                        playermov.enabled = true;
                        if (areEyes)
                        {
                            eyeder.enabled = true;
                            eyeizq.enabled = true;
                        }
                        playerTextContianer.SetActive(false);
                    }
                    else
                    {
                        ChangeDialogueLine(dialogos[i]);
                    }
                }
                else
                {
                    StopCoroutine(textAnimation);
                    if (currentSpeaker == "Player")
                    {
                        playerText.text = dialogos[i].Split(' ')[2];
                    }
                    else
                    {
                        npcText.text = dialogos[i].Split(' ')[2];
                    }
                    isTextAnimated = false;
                }
            }
        }
    }

    public bool GetIsTalking()
    {
        return isTalking;
    }

    private IEnumerator _TextAnimation(string line, TMP_Text text)
    {
        isTextAnimated = true;
        foreach (char character in line)
        {
            text.text += character;
            yield return new WaitForSeconds(0.2f);
        }
        isTextAnimated = false;
    }

    private void ChangeDialogueLine(string line)
    {
        string speaker = line.Split(' ')[0];
        string sprite = line.Split(' ')[1];
        string dialogue = line.Split(' ')[2];
        currentSpeaker = speaker;

        switch (sprite)
        {
            case "Red":
                currentSpearkerImage = playerImages[0];
                break;
            case "Blue":
                currentSpearkerImage = playerImages[1];
                break;
            case "Pink":
                currentSpearkerImage = playerImages[2];
                break;
            case "Grey":
                currentSpearkerImage = playerImages[3];
                break;
            default:
                break;
        }

        if (currentSpeaker == "Player")
        {
            npcTextContianer.SetActive(false);
            playerImage.sprite = currentSpearkerImage;
            playerTextContianer.SetActive(true);
            textAnimation = StartCoroutine(_TextAnimation(dialogue, playerText));
        }
        else
        {
            playerTextContianer.SetActive(false);
            npcImage.sprite = currentSpearkerImage;
            npcTextContianer.SetActive(true);
            textAnimation = StartCoroutine(_TextAnimation(dialogue, npcText));
        }
    }

    public void StratDialogue()
    {
        isTalking = true;
        if (areEyes)
        {
            eyeder.enabled = false;
            eyeizq.enabled = false;
        }
        rigidbody2D.velocity = new Vector2(0,0);
        playerani.enabled = false;
        playermov.enabled = false;
        anim.SetBool("Running", false);
        anim.SetBool("Ground", true);
        i = 0;
        ChangeDialogueLine(dialogos[0]);
        //text.text = dialogos[0];

    }
    public void FinishDialogue()
    {
        playerani.enabled = true;
        playermov.enabled = true;
        playerTextContianer.SetActive(false);
        npcTextContianer.SetActive(false);
        isTalking = false;
    }
}
