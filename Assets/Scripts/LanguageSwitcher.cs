using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{
    [SerializeField] private Text _text; // ��������� ���� � ����
    [SerializeField] private string _ru; // ������� �����
    [SerializeField] private string _en; // ���������� �����

    public void SetLanguage(string lang) // ����� ��� ��������� �����
    {
        switch (lang)
        {
            case "ru":
                _text.text = _ru; // ������ ����� �� �������
                break;
            case "en":
                _text.text = _en; // ������ ����� �� ����������
                break;
            default:
                Debug.LogError("Unknown language: " + lang); // ������� ������ ���� ���� ����������
                break;
        }
    }
}
