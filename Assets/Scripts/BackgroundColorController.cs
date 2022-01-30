using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColorController : MonoBehaviour
{
    [SerializeField] private EyeController rigthEye;
    [SerializeField] private EyeController leftEye;
    [SerializeField] private MeshRenderer grid;
    [SerializeField] private SpriteRenderer sun;
    [SerializeField] private bool changeColor = false;

    void Update()
    {
        if (changeColor)
        {
            if (rigthEye.IsClosed)
            {
                grid.gameObject.SetActive(true);
                grid.material.SetColor("_Color", new Color(0f, 0f, 1f));

                sun.gameObject.SetActive(true);
                sun.material.SetColor("_ColorA", new Color(0f, 0.156f, 1f));
                sun.material.SetColor("_ColorB", new Color(0f, 0.627f, 1f));

            }
            else if (leftEye.IsClosed)
            {
                grid.gameObject.SetActive(true);
                grid.material.SetColor("_Color", new Color(1f, 0f, 0f));

                sun.gameObject.SetActive(true);
                sun.material.SetColor("_ColorA", new Color(1f, 0f, 0f));
                sun.material.SetColor("_ColorB", new Color(1f, 0.2f, 0f));
            }
            else
            {
                grid.gameObject.SetActive(true);
                grid.material.SetColor("_Color", new Color(1f, 0f, 1f));

                sun.gameObject.SetActive(true);
                sun.material.SetColor("_ColorA", new Color(1f, 1f, 1f));
                sun.material.SetColor("_ColorB", new Color(1f, 1f, 1f));
            }

            if (leftEye.IsClosed && rigthEye.IsClosed)
            {
                grid.gameObject.SetActive(false);
                sun.gameObject.SetActive(false);
            }
        }
    }
}
