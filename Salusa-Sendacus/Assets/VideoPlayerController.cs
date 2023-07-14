using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string KarakterSecimSahnesi;

    void Start()
    {
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        if (vp == videoPlayer)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
