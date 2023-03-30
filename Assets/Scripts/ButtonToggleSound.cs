using UnityEngine;
using UnityEngine.UI;

public class ButtonToggleSound : MonoBehaviour
{
    public Image onImage;
    public Image offImage;

    private bool isOn = true;

    public void ToggleButton()
    {
        isOn = !isOn;

        if (isOn)
        {
            onImage.gameObject.SetActive(true);
            offImage.gameObject.SetActive(false);
            // All sounds are on, do nothing
            AudioManager.instance.ToggleOffMute();

            FindObjectOfType<AudioManager>().Play("Button");
        }
        else
        {
            onImage.gameObject.SetActive(false);
            offImage.gameObject.SetActive(true);
            // All sounds are off except for "Theme"
            AudioManager.instance.ToggleMute();

            FindObjectOfType<AudioManager>().Play("Button");
        }
    }
}


