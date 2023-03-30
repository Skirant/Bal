using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{   
    public int _coin;
    public int _coinReal;
    public int _bonusNumber;
    public int _nextbonus;
    [SerializeField] TextMeshProUGUI _coinGame;
    [SerializeField] TextMeshProUGUI[] _coinContinues;
    [SerializeField] TextMeshProUGUI _bonus;
    [SerializeField] TextMeshProUGUI _bonusText;

    public Animator animator;

    private void Start()
    {
        _coin = Progress.Instance.PlayerInfo._coin;
        if (_coinGame != null)
        {
            _coinGame.text = _coin.ToString();
        }
        transform.parent = null;
    }

    public void AddOne()
    {
        _coin++;
        _coinReal++;
        if (_coinGame != null)
        {
            _coinGame.text = _coin.ToString();
        }

        if(_bonus != null)
        {
            UpdateText();
        }
       

        switch (_coinReal)
        {
            case 25:
                _coinReal += 10;
                _bonusNumber = 10;
                _nextbonus = 50;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 50:
                _coinReal += 20;
                _bonusNumber = 20;
                _nextbonus = 100;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 100:
                _coinReal += 50;
                _bonusNumber = 50;
                _nextbonus = 200;
                animator.SetTrigger("Triger");
                UpdateText();
                break;
            case 200:
                _coinReal += 100;
                _bonusNumber = 100;
                _nextbonus = 400;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 400:
                _coinReal += 200;
                _bonusNumber = 200;
                _nextbonus = 800;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 800:
                _coinReal += 400;
                _bonusNumber = 400;
                _nextbonus = 1600;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 1600:
                _coinReal += 800;
                _bonusNumber = 800;
                _nextbonus = 3200;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 3200:
                _coinReal += 1600;
                _bonusNumber = 1600;
                _nextbonus = 6400;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 6400:
                _coinReal += 3200;
                _bonusNumber = 3200;
                _nextbonus = 12800;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
            case 12800:
                _coinReal += 6400;
                _bonusNumber = 6400;
                animator.SetTrigger("Triger");

                AudioManager.instance.Play("whoosh");

                UpdateText();
                break;
        }
    }

    public void SaveToProgress()
    {
        Progress.Instance.PlayerInfo._coin += _coinReal; 
    }

    public void UpdateText()
    {
        foreach (TextMeshProUGUI coinContinue in _coinContinues)
        {
            if (coinContinue != null)
            {
                coinContinue.text = _coinReal.ToString();
            }
        }

        if (Language.Instance.CurremtLanguage == "ru")
        {
            _bonus.text = "+" + _bonusNumber.ToString();
            _bonusText.text = "якедсчыхи анмся мю " + _nextbonus.ToString();
        }
        else
        {
            _bonus.text = "+" + _bonusNumber.ToString();
            _bonusText.text = "NEXT BONUS IS FOR " + _nextbonus.ToString();
        }
            
    }
}
