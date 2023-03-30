using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    public string LanguageName;

    public string CurremtLanguage;
    [SerializeField] TextMeshProUGUI _languageText;

    public static Language Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            CurremtLanguage = LanguageName;
            _languageText.text = CurremtLanguage.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
