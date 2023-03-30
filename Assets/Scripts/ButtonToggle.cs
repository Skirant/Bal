using UnityEngine;
using UnityEngine.UI;

public class ButtonToggle : MonoBehaviour
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
            AudioManager.instance.Play("Theme");
            FindObjectOfType<AudioManager>().Play("Button");
        }
        else
        {
            onImage.gameObject.SetActive(false);
            offImage.gameObject.SetActive(true);
            AudioManager.instance.Stop("Theme");
            FindObjectOfType<AudioManager>().Play("Button");
        }
    }
}
