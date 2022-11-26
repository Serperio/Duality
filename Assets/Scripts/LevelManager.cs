using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private DoorController dc;
    private SpriteRenderer whiteNoise;
    private GameObject PP;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        dc = GetComponent<DoorController>();
        PP = dc.PP;
        whiteNoise = dc.whiteNoise;
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("Dead", 1);
        PP.SetActive(false);
        whiteNoise.DOFade(1f, 1f).OnPlay(()=> {
            if (AudioManager.Instance.gameObject != null)
            {
                print("audio");
                AudioManager.Instance.PlaySFX(1);
            }
        }).OnComplete(() =>
        {
        string levelName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(levelName);
        });
    }
    
}
