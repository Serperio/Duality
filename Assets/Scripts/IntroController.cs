using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroController : MonoBehaviour
{

    [SerializeField]private SpriteRenderer whiteNoise;
    [SerializeField]private GameObject PP;
    private bool startGame;
    private float temp;
    private void Start()
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

    private void Update()
    {
        
    }
    private void ChangeChannel()
    {

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
                //AudioManager.Instance.PlayMusic("A");
                //AudioManager.Instance.PlayMusic("B");
                PP.SetActive(true);
            }));
        });
    }

}
