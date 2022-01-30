using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }

    private void Update()
    {
        if (!videoPlayer.isPlaying)
        {
            SceneManager.LoadScene("Title Scene");
        }
    }
}
