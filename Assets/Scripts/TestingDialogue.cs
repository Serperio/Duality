using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TestingDialogue : MonoBehaviour
{
    //public DialogueManager dialogueManager;
    public TMP_Text leftText;
    public GameObject leftTextContianer;
    public Image leftrImage;
    public TMP_Text rightText;
    public GameObject rightTextContianer;
    public Image rightImage;
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
            if (Input.GetKeyDown("x") || Input.GetKeyDown("z"))
            {
                if (!isTextAnimated)
                {
                    if (currentSpeaker == "L")
                    {
                        leftText.text = "";
                    }
                    else
                    {
                        rightText.text = "";
                    }
                    i += 1;

                    if (i > dialogos.Length - 1)
                    {
                        FinishDialogue();
                    }
                    else
                    {
                        ChangeDialogueLine(dialogos[i]);
                    }
                }
            }
        }
    }

    public bool GetIsTalking()
    {
        return isTalking;
    }

    private IEnumerator _TextAnimation(string line, TMP_Text dialogueText)
    {
        isTextAnimated = true;

        for (int i = 0; i < line.Length + 1; i++)
        {
            string sentence = line.Substring(0, i) + "<color=#0000>" + line.Substring(i) + "</color>";
            dialogueText.text = sentence;
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(0.1f);
        isTextAnimated = false;
    }

    private void ChangeDialogueLine(string line)
    {
        string speaker = line.Split(':')[0];
        string sprite = line.Split(':')[1];
        string dialogue = line.Split(':')[2];
        currentSpeaker = speaker;

        currentSpearkerImage = playerImages[i];
        
        if (currentSpeaker == "L")
        {
            rightTextContianer.SetActive(false);
            leftrImage.sprite = currentSpearkerImage;
            leftTextContianer.SetActive(true);
            textAnimation = StartCoroutine(_TextAnimation(dialogue, leftText));
        }
        if (currentSpeaker == "R")
        {
            leftTextContianer.SetActive(false);
            rightImage.sprite = currentSpearkerImage;
            rightTextContianer.SetActive(true);
            textAnimation = StartCoroutine(_TextAnimation(dialogue, rightText));
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
        leftTextContianer.SetActive(false);
        rightTextContianer.SetActive(false);
        isTalking = false;
        if (areEyes)
        {
            eyeder.enabled = true;
            eyeizq.enabled = true;
        }
    }
}
