using TMPro;
using UnityEngine;

public class InternationText : MonoBehaviour
{
    [SerializeField] string _en;
    [SerializeField] string _ru;

    private void Start()
    {
        if(Language.Instance.CurremtLanguage == "en")
        {
            GetComponent<TextMeshProUGUI>().text= _en;
        }
        else if(Language.Instance.CurremtLanguage == "ru")
        {
            GetComponent<TextMeshProUGUI>().text = _ru;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = _en;
        }
    }
}
