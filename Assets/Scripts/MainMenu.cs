using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] int NumberOfLevels;

    public void NextLevel()
    {


        NumberOfLevels++;
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(next);

        /*if (next < SceneManager.sceneCountInBuildSettings)
        {
            _coinManager.SaveToProgress();
            SceneManager.LoadScene(next);
        }

        if (next == 5)
        {
            next = 0;

            _coinManager.SaveToProgress();
            SceneManager.LoadScene(1);
        }

        Progress.Instance.PlayerInfo.Level = NumberOfLevels;
        _levelText.text = NumberOfLevels.ToString();
        Progress.Instance.PlayerInfo.CorrenctLevel = SceneManager.GetActiveScene().buildIndex;


        Progress.Instance.Save();*/
    }
}
