using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsOutlineController : MonoBehaviour
{
    private Material material;

    void Start()
    {
        Material outline = this.gameObject.GetComponent<SpriteRenderer>().material;
        if (transform.localScale.x < 2)
            outline.SetFloat("_Width", .6f);
        else if (transform.localScale.x > 40)
            outline.SetFloat("_Width", .99f);
        else if (transform.localScale.x > 5)
            outline.SetFloat("_Width", .95f);

        if (transform.localScale.y < 2)
            outline.SetFloat("_Height", .5f);
        else if (transform.localScale.y > 5)
            outline.SetFloat("_Height", .9f);
    }
}
