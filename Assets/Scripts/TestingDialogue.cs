using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingDialogue : MonoBehaviour
{
    //public DialogueManager dialogueManager;
    public Text texto;
    public string[] dialogos;
    bool talking;
    int num;
    int i;
    public PlayerAnimationController playerani;
    public PlayerMovement playermov;
    public Rigidbody2D rigidbody2D;
    public Animator anim;
    public EyeController eyeder;
    public EyeController eyeizq;
    public bool derClosed;
    public bool izqClosed;
    // Start is called before the first frame update
    void Start()
    {
        num = dialogos.Length;
        i = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("x") && talking)
        {
            texto.text = dialogos[i];
            i=i+1;
            if (i > num-1)
            {
                talking = false;
                playerani.enabled = true;
                playermov.enabled = true;
                eyeder.enabled = true;
                eyeizq.enabled = true;
                texto.enabled = false;
                gameObject.active = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        eyeder.enabled = false;
        eyeizq.enabled = false;
        rigidbody2D.velocity =new Vector2(0,0);
        playerani.enabled = false;
        playermov.enabled = false;
        anim.SetBool("Running", false);
        anim.SetBool("Ground", true);
        texto.enabled = true;
        i = 0;
        texto.text = dialogos[0];
        talking = true;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerani.enabled = true;
        playermov.enabled = true;
        texto.enabled = false;
        talking = false;

    }
}
