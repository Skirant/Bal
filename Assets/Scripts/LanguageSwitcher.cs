using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private Text _text; // текстовое поле в игре
    [SerializeField] private string _ru; // русский текст
    [SerializeField] private string _en; // английский текст

    public void SetLanguage(string lang) // метод для установки языка
    {
        switch (lang)
        {
            case "ru":
                _text.text = _ru; // меняем текст на русский
                break;
            case "en":
                _text.text = _en; // меняем текст на английский
                break;
            default:
                Debug.LogError("Unknown language: " + lang); // выводим ошибку если язык неизвестен
                break;
        }
    }
}
