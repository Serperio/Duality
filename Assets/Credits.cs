using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private RectTransform creditsContainer;
    [SerializeField]
    private SpriteRenderer whiteNoise;

    void Start()
    {
        whiteNoise.DOFade(0f, 1f).OnComplete(() =>
        {
            DOTween.To(() => creditsContainer.anchoredPosition, x => creditsContainer.anchoredPosition = x, new Vector2(0, 430), 40f).OnComplete(() => 
            {
                DOTween.Sequence().AppendInterval(5f).AppendCallback(() => 
                {
                    Debug.Log("bye bye");
                    Application.Quit();
                });
            });
        });
    }
}
