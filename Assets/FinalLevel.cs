using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FinalLevel : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer whiteNoise;
    [SerializeField]
    private Image whiteScreen;
    [SerializeField]
    private TestingDialogue dialogueManager;

    public void StartFinalLevel()
    {
        whiteNoise.DOFade(0, 1);

        whiteScreen.color = new Color(1, 1, 1, 0);

        DOTween.Sequence().AppendInterval(30f).Append(whiteScreen.DOFade(1, 30f).OnComplete(() => 
        {
            dialogueManager.StartDialogue();
        }).SetEase(Ease.InExpo));
    }
}
