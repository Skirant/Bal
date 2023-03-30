using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool timerIsRunning;

    void Start()
    {
        startTime = Time.time;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            float elapsedTime = Time.time - startTime;
            int minutes = (int)(elapsedTime / 60f);
            int seconds = (int)(elapsedTime % 60f);
            int milliseconds = (int)((elapsedTime % 1f) * 1000f);
            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }

    public void ToggleTimer()
    {
        timerIsRunning = !timerIsRunning;
    }

    public void ResetTimer()
    {
        startTime = Time.time;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }
}
