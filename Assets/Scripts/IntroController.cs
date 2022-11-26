using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{

    [SerializeField]private SpriteRenderer whiteNoise;
    [SerializeField]private GameObject PP;
    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject mountains;
    [SerializeField] private GameObject grid;
    [SerializeField] private GameObject sun;
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject blackScreen;
    private int counter = 0;
    private float originalVolume;
    private bool startGame;
    private float temp;
    private bool lockControl = false;
    private void Start()
    {
        AudioManager.Instance.StopMusic("A");
        AudioManager.Instance.StopMusic("B");
        whiteNoise.DOFade(0, 1).OnPlay(() => startGame = false);
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(.3f).Append(DOTween.To(() => temp, x => temp = x, 1, 0.2f).OnPlay(() =>
        {
            //AudioManager.Instance.PlayMusic("A");
            //AudioManager.Instance.PlayMusic("B");
            PP.SetActive(true);
        }));
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && lockControl == false)
        {
            ChangeChannel();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && lockControl == false)
        {
            ChangeChannel();
        }
    }

    private void StartLevel()
    {
        whiteNoise.DOFade(1, 1).OnPlay(() => {
            PP.SetActive(false);
            if (AudioManager.Instance.gameObject != null)
            {
                print("audio");
                AudioManager.Instance.Play(1);
            }

        }).OnComplete(() => SceneManager.LoadScene("L1"));
    }

    private void ChangeChannel()
    {
        lockControl = true;
        counter++;
        PP.SetActive(false);
        whiteNoise.DOFade(1f, 1f).OnPlay(() => {
            if (AudioManager.Instance.gameObject != null)
            {
                print("audio");
                AudioManager.Instance.Play(1);
            }
        }).OnComplete(() =>
        {
            DOTween.Sequence().AppendInterval(0.5f).Append(whiteNoise.DOFade(0, 1));
            Sequence sequence = DOTween.Sequence();
            sequence.AppendInterval(.8f).Append(DOTween.To(() => temp, x => temp = x, 1, 0.2f).OnPlay(() =>
            {
                lockControl = false;
                if (counter > 2)
                {
                    AudioManager.Instance.PlayMusic("A");
                    AudioManager.Instance.PlayMusic("B");
                    blackScreen.SetActive(false);
                    sky.SetActive(true);
                    logo.SetActive(true);
                    sun.SetActive(true);
                    mountains.SetActive(true);
                    grid.SetActive(true);
                    lockControl = true;
                    Invoke("StartLevel", 4f);
                }
                PP.SetActive(true);
            }));
        });
    }

}
