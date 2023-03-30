using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    public float timeRemaining;
    [SerializeField] GameOver gameOver;
    private const float timerMax = 20f;
    public Slider slider;
    public Timer timer;

    private void Update()
    {
        slider.value = CalculateSliderValue();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            timeRemaining = timerMax;
        }

        if(timeRemaining <= 0)
        {
            gameOver.GameOff();
            timeRemaining = 0;
            timer.StopTimer();
        }
        else if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    float CalculateSliderValue()
    {
        return(timeRemaining / timerMax);
    }

    public void RestartTimer()
    {
        timeRemaining = timerMax;
    }
}
