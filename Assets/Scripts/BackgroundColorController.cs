using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (GameObject.Find("Player") != null)
            {
                if (leftEye.IsClosed && rigthEye.IsClosed)
                {
                    //GameObject.Find("Player").GetComponent<PlayerAnimationController>().ToGray();
                    GameObject.Find("Player").GetComponent<SpriteSwap>().Folder = "D";
                    GameObject.Find("Player").GetComponent<SpriteRenderer>().material.SetColor("_GlowColor", new Color32(0, 0, 0, 0));
                    grid.gameObject.SetActive(false);
                    sun.gameObject.SetActive(false);
                }
                else
                {
                    if (rigthEye.IsClosed)
                    {
                        //GameObject.Find("Player").GetComponent<PlayerAnimationController>().ToBlue();
                        GameObject.Find("Player").GetComponent<SpriteSwap>().Folder = "C";
                        GameObject.Find("Player").GetComponent<SpriteRenderer>().material.SetColor("_GlowColor", new Color32(0, 64, 87, 0));
                        grid.gameObject.SetActive(true);
                        grid.material.SetColor("_Color", new Color(0f, 0f, 1f));

                        sun.gameObject.SetActive(true);
                        sun.material.SetColor("_ColorA", new Color(0f, 0.156f, 1f));
                        sun.material.SetColor("_ColorB", new Color(0f, 0.627f, 1f));

                    }
                    else if (leftEye.IsClosed)
                    {
                        //GameObject.Find("Player").GetComponent<PlayerAnimationController>().ToRed();
                        GameObject.Find("Player").GetComponent<SpriteSwap>().Folder = "B";
                        GameObject.Find("Player").GetComponent<SpriteRenderer>().material.SetColor("_GlowColor", new Color32(118, 13, 13, 0));
                        grid.gameObject.SetActive(true);
                        grid.material.SetColor("_Color", new Color(1f, 0f, 0f));

                        sun.gameObject.SetActive(true);
                        sun.material.SetColor("_ColorA", new Color(1f, 0f, 0f));
                        sun.material.SetColor("_ColorB", new Color(1f, 0.2f, 0f));
                    }
                    else
                    {
                        //GameObject.Find("Player").GetComponent<PlayerAnimationController>().ToPurple();
                        GameObject.Find("Player").GetComponent<SpriteSwap>().Folder = "A";
                        GameObject.Find("Player").GetComponent<SpriteRenderer>().material.SetColor("_GlowColor", new Color32(103, 0, 97, 0));
                        grid.gameObject.SetActive(true);
                        grid.material.SetColor("_Color", new Color(1f, 0f, 1f));

                        sun.gameObject.SetActive(true);
                        sun.material.SetColor("_ColorA", new Color(1f, 1f, 1f));
                        sun.material.SetColor("_ColorB", new Color(1f, 1f, 1f));
                    }

                }
            }
        }
    }
}
