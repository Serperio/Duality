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


    private float counter = 0;
    private bool isPowerActived = false;
    private bool isAlive = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            if (!isPowerActived)
            {
                counter += Time.deltaTime;

                if (counter >= 5)
                {
                    counter = 0;
                    Debug.Log("Entre");
                    if (AudioManager.Instance.gameObject != null)
                    {
                        print("audio");
                        AudioManager.Instance.Play(4);
                    }
                    DOTween.To(() => medusaRightEye.pointLightOuterRadius, x => medusaRightEye.pointLightOuterRadius = x, 10f, 1f).OnComplete(() =>
                    {
                        DOTween.To(() => medusaRightEye.pointLightOuterRadius, x => medusaRightEye.pointLightOuterRadius = x, 0f, 1f);

                    });
                    Sequence medusa = DOTween.Sequence();
                    int num = 0;
                    medusa.AppendInterval(1).Append(DOTween.To(() => num, x => num = x, 1, 0.2f).OnPlay(() => isPowerActived = true));
                    medusa = DOTween.Sequence();
                    num = 0;
                    medusa.AppendInterval(1.5f).Append(DOTween.To(() => num, x => num = x, 1, 0.2f).OnPlay(() => isPowerActived = false));
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
    }

    private void CheckEyes()
    {      
        if (!playerRightEye.IsClosed || !playerleftEye.IsClosed)
        {
            LevelManager.instance.ResetLevel();
        }
    }

    public void KillMedusa()
    {
        isAlive = true;
    }
}
