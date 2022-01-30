using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    [SerializeField] private EyeController rigthEye;
    [SerializeField] private EyeController leftEye;
    [SerializeField] private List<Sprite> eyesSprites;
    private SpriteRenderer rightSpriteRenderer;
    private SpriteRenderer leftSpriteRenderer;

    void Start()
    {
        rightSpriteRenderer = rigthEye.openEye.GetComponent<SpriteRenderer>();
        leftSpriteRenderer = leftEye.openEye.GetComponent<SpriteRenderer>();
        leftSpriteRenderer.sprite = eyesSprites[3];
        rightSpriteRenderer.sprite = eyesSprites[3];
    }

    void Update()
    {
        if (leftEye.IsClosed && rigthEye.IsClosed)
        {
            rightSpriteRenderer.sprite = eyesSprites[0];
            leftSpriteRenderer.sprite = eyesSprites[0];
        }
        else
        {
            if (rigthEye.IsClosed)
            {
                rightSpriteRenderer.sprite = eyesSprites[0];
                leftSpriteRenderer.sprite = eyesSprites[2];

            }
            else if (leftEye.IsClosed)
            {
                leftSpriteRenderer.sprite = eyesSprites[0];
                rightSpriteRenderer.sprite = eyesSprites[1];
            }
            else
            {
                leftSpriteRenderer.sprite = eyesSprites[3];
                rightSpriteRenderer.sprite = eyesSprites[3];
            }
        }
    }
}
