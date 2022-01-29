using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGGridScroll : MonoBehaviour
{
    public float scrollSpeed = 0.1f;
    private MeshRenderer meshRenderer;
    private float xScroll;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        Scroll();
    }

    private void Scroll()
    {
        xScroll = Time.time * scrollSpeed;
        Vector2 offset = new Vector2(0f, xScroll);
        meshRenderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
