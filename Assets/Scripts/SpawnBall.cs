using System.Collections;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject[] ballPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    [SerializeField] float indentX;
    [SerializeField] float indentY;

    public bool spawn;

    [SerializeField] WindowsShop windowsShop;
    [SerializeField] SpawnCloud spawnCloud;
    [SerializeField] TimerSlider timerSlider;

    private void Start()
    {
        StartCoroutine(BallSpawn());        
    }

    private void FixedUpdate()
    {
        windowsShop = FindObjectOfType<WindowsShop>();
        spawnCloud = FindObjectOfType<SpawnCloud>();
        timerSlider = FindObjectOfType<TimerSlider>();

        float halfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        minTras = -halfWidth + indentX;
        maxTras = halfWidth - indentX;

        // Check for the presence of the ShopManager script
        if (windowsShop != null)
        {
            spawn = false;
        }

        // Otherwise, check for the presence of the SpawnCloud and TimerSlider scripts
        if (spawnCloud != null)
        {
            if (!spawn)
            {
                spawn = true;
                StartCoroutine(BallSpawn()); // Start the coroutine again
            }
        }

        if (timerSlider != null)
        {
            if (!spawn & timerSlider.timeRemaining > 0) // Check if the coroutine is not running
            {
                spawn = true;
                StartCoroutine(BallSpawn()); // Start the coroutine again
            }
            else if (timerSlider.timeRemaining < 0)
            {
                spawn = false;
            }
        }
    }

    IEnumerator BallSpawn()
    {
        while (spawn)
        {
            var wanted = Random.Range(minTras, maxTras);
            var bottomOfScreen = Camera.main.transform.position.y - Camera.main.orthographicSize;
            var position = new Vector3(wanted, bottomOfScreen - indentY);
            GameObject gameObject = Instantiate(ballPrefab[Random.Range(0, ballPrefab.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 25f);
        }
    }

    public void AddBallPrefab(GameObject ball)
    {
        // Create a new array with a size larger than the current ballPrefab array
        GameObject[] newBallPrefab = new GameObject[ballPrefab.Length + 1];
        // Copy the existing ballPrefab array to the new array
        for (int i = 0; i < ballPrefab.Length; i++)
        {
            newBallPrefab[i] = ballPrefab[i];
        }
        // Add the new ball prefab to the end of the new array
        newBallPrefab[newBallPrefab.Length - 1] = ball;
        // Set the ballPrefab array to the new array
        ballPrefab = newBallPrefab;
    }
}
