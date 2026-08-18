using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image timeImage;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float duration, currentTime;

    bool timerRunning = true;

    void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while (currentTime >= 0 && timerRunning)
        {
            if (EndingManager.instance.IsEndingShown())
            {
                timerRunning = false;
                yield break;
            }

            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            timeText.text = currentTime.ToString();

            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        if (timerRunning)
        {
            EndingManager.instance.TimeUp();
            OpenPanel();
        }
    }

    void OpenPanel()
    {
        timeText.text = "";
        panel.SetActive(true);
    }
}
