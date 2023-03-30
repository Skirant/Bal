using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _gameOverImage;
    [SerializeField] GameObject _sliser;
    [SerializeField] GameObject _score;
    [SerializeField] SpawnBall _spawnBall;
    [SerializeField] Animator animator;

    private GameObject[] ballsObjects;

    public void GameOff()
    {
        ballsObjects = GameObject.FindGameObjectsWithTag("Balls");

        _spawnBall = FindObjectOfType<SpawnBall>();

        for (int i = 0; i < ballsObjects.Length; ++i)
        {
            Destroy(ballsObjects[i]);
        }

       _spawnBall.spawn = false;

        animator.SetTrigger("GameOver");

        _gameOverImage.SetActive(true);
        _sliser.SetActive(false);
        _score.SetActive(false);
    }
}
