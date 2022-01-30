using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SunAnimation : MonoBehaviour
{
    [SerializeField] [Range(2.0f, 70.0f)] private float time = 4.29f;
    Material material;
    bool isAnimated = false;
    Sequence sequence;
    int num = 0;

    private void Start()
    {
        material = gameObject.GetComponent<SpriteRenderer>().material;
        material.SetFloat("_TransparencyA", -0.6f);
        material.SetFloat("_TransparencyB", 0.6f);
    }

    private void Update()
    {
        if (!isAnimated)
        {
            DOTween.To(() => material.GetFloat("_TransparencyA"), x => material.SetFloat("_TransparencyA", x), 0.6f, time).OnPlay(() =>
            {
                material.SetFloat("_Phase", 1);
                isAnimated = true;
            }).OnComplete(() => material.SetFloat("_TransparencyA", -0.6f)).SetEase(Ease.Linear);

            sequence = DOTween.Sequence();
            sequence.AppendInterval(time - 3f)
                .Append(DOTween.To(() => material.GetFloat("_TransparencyB"), x => material.SetFloat("_TransparencyB", x), -0.6f, time)).OnComplete(() => material.SetFloat("_TransparencyB", 0.6f)).SetEase(Ease.Linear);

            sequence = DOTween.Sequence();
            sequence.AppendInterval(time - 1.5f).Append(DOTween.To(() => num, x => num = x, 1, 0.2f).OnPlay(() => material.SetFloat("_Phase", 0)));

            sequence = DOTween.Sequence();
            sequence.AppendInterval(time + .5f).Append(DOTween.To(() => num, x => num = x, 0, 0.2f).OnPlay(() =>
            {
                isAnimated = false;
            }));
        }
    }
}
