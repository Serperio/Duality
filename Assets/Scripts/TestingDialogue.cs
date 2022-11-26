using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TestingDialogue : MonoBehaviour
{
    //private DialogueManager dialogueManager;
    [SerializeField]
    private Image blackImage;
    [SerializeField]
    private Material glowMaterial;
    [SerializeField]
    private TMP_Text leftText;
    [SerializeField]
    private GameObject leftTextContianer;
    [SerializeField]
    private Image leftImage;
    [SerializeField]
    private TMP_Text rightText;
    [SerializeField]
    private GameObject rightTextContianer;
    [SerializeField]
    private Image rightImage;
    [SerializeField]
    private string[] dialogos;

    [SerializeField]
    private List<Sprite> playerImages;

    bool isTalking;
    int i;
    [SerializeField]
    private PlayerAnimationController playerani;
    [SerializeField]
    private PlayerMovement playermov;
    [SerializeField]
    private Rigidbody2D rigidbody2D;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private EyeController eyeder;
    [SerializeField]
    private EyeController eyeizq;
    [SerializeField]
    private bool areEyes;

    [SerializeField]
    private DoorController doorController;

    private bool isTextAnimated = false;
    private Coroutine textAnimation;
    private string currentSpeaker;
    private Sprite currentSpearkerImage;

    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        leftImage.material = Instantiate(glowMaterial);
        blackImage.color = new Color32(49, 60, 57, 255);
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
        string dialogue = line.Split(':')[1];
        currentSpeaker = speaker;

        currentSpearkerImage = playerImages[i];
        
        if (currentSpeaker == "L")
        {
            //rightTextContianer.SetActive(false);
            leftImage.sprite = currentSpearkerImage;
            leftImage.material.SetTexture("_MainTex", currentSpearkerImage.texture);
            leftTextContianer.SetActive(true);
            textAnimation = StartCoroutine(_TextAnimation(dialogue, leftText));
        }
        if (currentSpeaker == "R")
        {
            leftTextContianer.SetActive(false);
            rightImage.sprite = currentSpearkerImage;
            rightImage.material.SetTexture("_MainTex", currentSpearkerImage.texture);
            rightTextContianer.SetActive(true);
            textAnimation = StartCoroutine(_TextAnimation(dialogue, rightText));
        }
    }

    public void StartDialogue()
    {
        blackImage.gameObject.SetActive(true);
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
        blackImage.DOFade(0, 1f);
        doorController.WhiteNoiseAnim();
        playerani.enabled = true;
        playermov.enabled = true;
        leftTextContianer.SetActive(false);
        //rightTextContianer.SetActive(false);
        isTalking = false;
        if (areEyes)
        {
            eyeder.enabled = true;
            eyeizq.enabled = true;
        }
    }
}
