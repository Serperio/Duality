using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public class Medusa : MonoBehaviour
{
    [SerializeField] private EyeController playerRightEye;
    [SerializeField] private EyeController playerleftEye;

    [SerializeField] private Light2D medusaRightEye;
    [SerializeField] private Light2D medusaLeftEye;


    private int randomNumber;
    private bool isPowerActived = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPowerActived)
        {
            randomNumber = Random.Range(0, 2000);

            if (randomNumber == 300)
            {
                Debug.Log("Entre");
                DOTween.To(() => medusaRightEye.pointLightOuterRadius, x => medusaRightEye.pointLightOuterRadius = x, 10f, 1f).OnPlay(() => isPowerActived = true).OnComplete(() =>
                {                  
                    DOTween.To(() => medusaRightEye.pointLightOuterRadius, x => medusaRightEye.pointLightOuterRadius = x, 0f, 1f).OnComplete(() => isPowerActived = false);
                });
                DOTween.To(() => medusaLeftEye.pointLightOuterRadius, x => medusaLeftEye.pointLightOuterRadius = x, 10f, 1f).OnComplete(() =>
                {
                    DOTween.To(() => medusaLeftEye.pointLightOuterRadius, x => medusaLeftEye.pointLightOuterRadius = x, 0f, 1f);
                });
            }
        }

        if (isPowerActived)
        {
            CheckEyes();
        }
    }

    private void CheckEyes()
    {
        
        if (!playerRightEye.IsClosed || !playerleftEye.IsClosed)
        {
            Debug.Log("moriste");
        }
    }
}
