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
    private Image whiteScreen;

    void Start()
    {
        whiteScreen.color = new Color(1, 1, 1, 0);

        DOTween.Sequence().AppendInterval(30f).Append(whiteScreen.DOFade(1, 30f));
    }
}