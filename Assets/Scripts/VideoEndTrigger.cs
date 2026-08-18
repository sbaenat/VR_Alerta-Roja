using UnityEngine;
using UnityEngine.Video;

public class VideoEndTrigger : MonoBehaviour
{
    //public VideoPlayer videoPlayer;
    //public GameObject targetObject;
    //public GameObject hideObject;

    //void Start()
    //{
    //    videoPlayer.loopPointReached += OnVideoEnd;
    //}

    //void OnVideoEnd(VideoPlayer vp)
    //{
    //    targetObject.SetActive(true);
    //    hideObject.SetActive(false);
    //}

    public VideoPlayer videoPlayer;
    public GameObject targetObject;
    public GameObject hideObject;
    public double triggerTime = 40.0; // tiempo en segundos

    private bool triggered = false;

    void Update()
    {
        if (!triggered && videoPlayer.time >= triggerTime)
        {
            triggered = true;
            targetObject.SetActive(true);
            hideObject.SetActive(false);
        }
    }
}
