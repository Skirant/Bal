using UnityEngine;

public class WindowsShop : MonoBehaviour
{
    [SerializeField] GameObject _windowBalls;
    [SerializeField] GameObject _windowBackground;

    public void WindowBallsON()
    {
        _windowBalls.SetActive(true);
        _windowBackground.SetActive(false);

        if(FindObjectOfType<AudioManager>() == null)
        {
            return;
        }
        FindObjectOfType<AudioManager>().Play("Button");
    }
    public void WindowBackgroundON()
    {
        _windowBalls.SetActive(false);
        _windowBackground.SetActive(true);

        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().Play("Button");
        }  
    }
    public void WindowGameON()
    {
        _windowBalls.SetActive(false);
        _windowBackground.SetActive(false);

        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().Play("Button");
        }
    }
}
