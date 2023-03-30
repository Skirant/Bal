using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwitcher : MonoBehaviour
{
    public Image[] sprites;
    public bool[] imageBools;

    public int currentIndex;

    [SerializeField] TimerSlider timerSlider;

    private void Awake()
    {
        imageBools = new bool[9];
    }

    private void Start()
    {
        currentIndex = Progress.Instance.PlayerInfo._curectBackground; 
    }

    void Update()
    {
        // Check for image toggles
        for (int i = 0; i < imageBools.Length; i++)
        {
            if (imageBools[i])
            {
                // Disable all other images and select the current one
                currentIndex = i;                

                SetImage();
                Purchase(i);

                // Reset all other bools to false
                for (int j = 0; j < imageBools.Length; j++)
                {
                    if (j != i)
                    {
                        imageBools[j] = false;
                    }
                }
            }
        }
    }

    void FixedUpdate()
    {
        timerSlider = FindObjectOfType<TimerSlider>();

        if (timerSlider != null)
        {
            sprites = GameObject.FindGameObjectsWithTag("BackGround")
                .Select(go => go.GetComponent<Image>())
                .ToArray();
        }


        // Enable the selected image
        SetImage();
    }

    void SetImage()
    {
        // Disable all images
        foreach (Image image in sprites)
        {
            image.enabled = false;
        }

        // Enable the selected image
        if (currentIndex >= 0 && currentIndex < sprites.Length)
        {
            sprites[currentIndex].enabled = true;
        }

        Progress.Instance.PlayerInfo._curectBackground  = currentIndex;
    }

    public void Purchase(int batNo)
    {
        currentIndex = batNo + 1;
    }
}