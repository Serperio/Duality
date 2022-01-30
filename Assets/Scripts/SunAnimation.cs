using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SunAnimation : MonoBehaviour
{
    Material material;
    bool isAnimated = false;
    Sequence sequence;
    int num = 0;

    private void Start()
    {
        material = gameObject.GetComponent<SpriteRenderer>().material;
        material.SetFloat("_TransparencyA", -0.8f);
        material.SetFloat("_TransparencyB", 0.8f);
    }

    private void Update()
    {
        if (!isAnimated)
        {
            DOTween.To(() => material.GetFloat("_TransparencyA"), x => material.SetFloat("_TransparencyA", x), 0.8f, 50f).OnPlay(() =>
            {
                material.SetFloat("_Phase", 1);
                isAnimated = true;
            }).OnComplete(() => material.SetFloat("_TransparencyA", -0.8f)).SetEase(Ease.Linear);

            sequence = DOTween.Sequence();
            sequence.AppendInterval(20f)
                .Append(DOTween.To(() => material.GetFloat("_TransparencyB"), x => material.SetFloat("_TransparencyB", x), -0.8f, 50f)).OnComplete(() => material.SetFloat("_TransparencyB", 0.8f)).SetEase(Ease.Linear);

            sequence = DOTween.Sequence();
            sequence.AppendInterval(45f).Append(DOTween.To(() => num, x => num = x, 1, 0.2f).OnPlay(() => material.SetFloat("_Phase", 0)));

            sequence = DOTween.Sequence();
            sequence.AppendInterval(55f).Append(DOTween.To(() => num, x => num = x, 0, 0.2f).OnPlay(() =>
            {
                isAnimated = false;
            }));
        }
    }
}
