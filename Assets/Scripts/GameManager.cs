using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject _settingsMenu;
    public int NumberOfLevels;

    public void SettingsON()
    {
        _settingsMenu.SetActive(true);
        Sound();
    }

    public void SettingsOFF()
    {
        _settingsMenu.SetActive(false);
        Sound();
    }

    public void StoreON()
    {
        SceneManager.LoadScene(2);

        FindObjectOfType<CoinManager>().SaveToProgress();

        Sound();

        Progress.Instance.Save();
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);

        Progress.Instance.PlayerInfo._numberOfLevel = 0;

        FindObjectOfType<CoinManager>().SaveToProgress();

        Sound();

        Progress.Instance.Save();
    }
    public void Play()
    {
        SceneManager.LoadScene(1);

        Progress.Instance.PlayerInfo._numberOfLevel = 1;

        FindObjectOfType<CoinManager>().SaveToProgress();

        Sound();
    }

    public void Back()
    {
        NumberOfLevels = Progress.Instance.PlayerInfo._numberOfLevel;
        SceneManager.LoadScene(NumberOfLevels);

        Sound();

        Progress.Instance.Save();
    }

    private void Sound()
    {
        if (FindObjectOfType<AudioManager>() == null)
        {
            return;
        }

        FindObjectOfType<AudioManager>().Play("Button");
    }
}
