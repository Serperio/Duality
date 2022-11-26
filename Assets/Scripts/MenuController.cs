using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField]private int index = 1;
    [SerializeField] private GameObject credits;
    [SerializeField] private SpriteRenderer whiteNoise;
    [SerializeField] private GameObject PP;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (AudioManager.Instance.gameObject != null)
            {
                print("audio");
                AudioManager.Instance.PlaySFX(0);
            }
            index++;
            if (index > 3) index = 1;
            HighlightWord();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (AudioManager.Instance.gameObject != null) {
                print("audio");
                AudioManager.Instance.PlaySFX(0);
            }
            index--;
            if (index < 1) index = 3;
            HighlightWord();
        }
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
        {
            if (AudioManager.Instance.gameObject != null)
            {
                print("audio");
                AudioManager.Instance.PlaySFX(0);
            }
            print(credits.activeSelf);
            if (credits.activeSelf)
            {
                credits.SetActive(false);
            }
            else
            {
                switch (index)
                {
                    case 1:
                        //Pasar a primer nivel
                        whiteNoise.DOFade(1, 1).OnPlay(()=> { 
                            PP.SetActive(false);
                            if (AudioManager.Instance.gameObject != null)
                            {
                                print("audio");
                                AudioManager.Instance.PlaySFX(1);
                            }

                        }).OnComplete(()=>SceneManager.LoadScene("Level 1"));
                        break;
                    case 2:
                        //Mostrar creditos
                        credits.SetActive(true);
                        break;
                    case 3:
                        //Cerrar juego
                        Application.Quit();
                        break;

                }
            }
            
        }

    }
    private void HighlightWord()
    {
        for (int i = 1; i < transform.childCount-1; i++)
        {
            transform.GetChild(i).GetComponent<TextMeshProUGUI>().color = new Color32(164,164,164,255);
        }
        transform.GetChild(index).GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, 255);
    }
}
