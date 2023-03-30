using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSM : MonoBehaviour
{
    public int coins;
    [SerializeField] TextMeshProUGUI _currectCoin;

    public ShopItemSO[] shopItemSO;
    public StoreTemplate[] storePanel;
    public GameObject[] shopPanelSO;
    public Button[] myPurchaceBtns;
    public Button[] buttonON;

    public BackgroundSwitcher backgroundSwitcher;

    public LoadSceneBackGround loadSceneBackGround;

    public Language language;
    private void Start()
    {
        loadSceneBackGround = FindObjectOfType<LoadSceneBackGround>();

        backgroundSwitcher = FindObjectOfType<BackgroundSwitcher>();

        language = FindObjectOfType<Language>();

        coins = Progress.Instance.PlayerInfo._coin;
        _currectCoin.text = coins.ToString();

        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelSO[i].SetActive(true);
        }
        LoadPanels();

        CheckPutchaseable();

        CheckSale();

        CheckONBackGround();
    }

    public void CheckPutchaseable()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (coins >= shopItemSO[i].baseCost)
            {
                myPurchaceBtns[i].interactable = true;
            }
            else
            {
                myPurchaceBtns[i].interactable = false;
            }
        }
    }

    public void CheckSale()
    {
        for (int i = 0; i < loadSceneBackGround._sale.Length; i++)
        {
            if (loadSceneBackGround._sale[i])
            {
                buttonON[i].gameObject.SetActive(true);

                myPurchaceBtns[i].GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(false);
                myPurchaceBtns[i].GetComponentInChildren<Image>(true).gameObject.SetActive(false);
            }
        }
    }



    public void PurchaseItem(int batNo)
    {
        if (coins >= shopItemSO[batNo].baseCost && shopItemSO[batNo].baseCost > 0)
        {
            coins = coins - shopItemSO[batNo].baseCost;
            _currectCoin.text = coins.ToString();
            CheckPutchaseable();
            // Add the new ball prefab to the SpawnBall script's ballPrefab array
            backgroundSwitcher.currentIndex = batNo + 1;
            Progress.Instance.PlayerInfo._coin = coins;

            buttonON[batNo].gameObject.SetActive(true);

            if (Language.Instance.CurremtLanguage == "ru")
            {
                buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>(true).text = "¬ À";
            }
            else
            {
                buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>(true).text = "ON";
            }
                
            myPurchaceBtns[batNo].GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(false);

            Image imageComponent = myPurchaceBtns[batNo].GetComponent<Image>();
            if (imageComponent != null)
            {
                Destroy(imageComponent.gameObject);
            }
            // Set the base cost to zero to indicate that the item has been purchased

            loadSceneBackGround.Purchase(batNo);

            ButtonText(batNo);

            if (FindObjectOfType<AudioManager>() != null)
            {
                FindObjectOfType<AudioManager>().Play("Button");
            }
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (language.CurremtLanguage == "en")
            {
                storePanel[i].titleText.text = shopItemSO[i].titleEn;
            }
            else if (language.CurremtLanguage == "ru")
            {
                storePanel[i].titleText.text = shopItemSO[i].titleRu;
            }


            storePanel[i].CostText.text = shopItemSO[i].baseCost.ToString();
        }
    }

    
    public void ButtonON(int batNo)
    {
        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().Play("Button");
        }

        if (Language.Instance.CurremtLanguage == "ru")
        {
            if (buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text == "¬€ À")
            {
                buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text = "¬ À";
            }
        }
        else
        {
            if (buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text == "OFF")
            {
                buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text = "ON";
            }
        }

        if (Language.Instance.CurremtLanguage == "ru")
        {

            if (buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text == "¬ À")
            {
                for (int i = 0; i < buttonON.Length; i++)
                {
                    if (i != batNo && buttonON[i].gameObject.activeSelf && buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text == "¬ À")
                    {
                        buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "¬€ À";
                    }
                }
            }
        }
        else
        {

            if (buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text == "ON")
            {
                for (int i = 0; i < buttonON.Length; i++)
                {
                    if (i != batNo && buttonON[i].gameObject.activeSelf && buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text == "ON")
                    {
                        buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "OFF";
                    }
                }
            }
        }
        backgroundSwitcher.currentIndex = batNo;
    }

    public void ButtonText(int batNo)
    {
        if (Language.Instance.CurremtLanguage == "ru")
        {
            if (buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text == "¬ À")
            {
                for (int i = 0; i < buttonON.Length; i++)
                {
                    if (i != batNo && buttonON[i].gameObject.activeSelf && buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text == "¬ À")
                    {
                        buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "¬€ À";
                    }
                }
            }
        }
        else
        {
            if (buttonON[batNo].GetComponentInChildren<TextMeshProUGUI>().text == "ON")
            {
                for (int i = 0; i < buttonON.Length; i++)
                {
                    if (i != batNo && buttonON[i].gameObject.activeSelf && buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text == "ON")
                    {
                        buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "OFF";
                    }
                }
            }
        }
    }

    public void CheckONBackGround()
    {
        for (int i = 0; i < buttonON.Length; i++)
        {
            if(Language.Instance.CurremtLanguage == "ru")
            {
                if (i == backgroundSwitcher.currentIndex)
                {
                    buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "¬ À";
                }
                else
                {
                    buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "¬€ À";
                }
            }
            else
            {
                if(i == backgroundSwitcher.currentIndex)
                {
                    buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "ON";
                }
                else
                {
                    buttonON[i].GetComponentInChildren<TextMeshProUGUI>().text = "OFF";
                }
            }
        }
    }
}
