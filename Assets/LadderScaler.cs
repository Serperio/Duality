using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScaler : MonoBehaviour
{
    [SerializeField]
    private Material material;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.material = Instantiate(material);
        float scaleY = gameObject.transform.localScale.y;
        float scale = 0.8f;
        if (scaleY > 5)
            scale = 1.5f;
        if (scaleY > 10)
            scale = (gameObject.transform.localScale.y * 2f - 5f) / 10f;
        spriteRenderer.material.SetFloat("_Scale", scale);
    }
}
