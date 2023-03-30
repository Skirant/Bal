using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    private VideoPlayer _videoPlayer;

    private void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.url = Application.streamingAssetsPath + "/AllBall.mp4";
        Play();
    }

    private void Play()
    {
        _videoPlayer.Play();
        _videoPlayer.isLooping = true;
    }
}
