using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int coins;
    [SerializeField] TextMeshProUGUI _currectCoin;

    public ShopItemSO[] shopItemSO;
    public StoreTemplate[] storePanel;
    public GameObject[] shopPanelSO;
    public Button[] myPurchaceBtns;
    public GameObject[] purchaseTextObjects;

    public SpawnBall spawnBall;
    public LoadSceneShop loadSceneShop;

    public Language language;


    private void Start()
    {
        spawnBall = FindObjectOfType<SpawnBall>();

        language = FindObjectOfType<Language>();

        coins = Progress.Instance.PlayerInfo._coin;
        _currectCoin.text = coins.ToString();

        for (int i = 0; i < shopItemSO.Length; i++)
        {
            shopPanelSO[i].SetActive(true);
        }

        LoadPanels();

        CheckPutchaseable();

        loadSceneShop = FindObjectOfType<LoadSceneShop>();

        CheckSale();
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
        for (int i = 0; i < loadSceneShop._sale.Length; i++)
        {
            if (loadSceneShop._sale[i])
            {
                myPurchaceBtns[i].GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(false);
                myPurchaceBtns[i].GetComponentInChildren<Image>(true).gameObject.SetActive(false);

                purchaseTextObjects[i].SetActive(true);
            }
        }
    }

    public void PurchaseItem(int batNo)
    {
        if (coins >= shopItemSO[batNo].baseCost)
        {
            coins = coins - shopItemSO[batNo].baseCost;
            _currectCoin.text = coins.ToString();
            CheckPutchaseable();
            // Add the new ball prefab to the SpawnBall script's ballPrefab array
            spawnBall.AddBallPrefab(shopItemSO[batNo].ballPrefab);
            Progress.Instance.PlayerInfo._coin = coins;

            myPurchaceBtns[batNo].GetComponentInChildren<TextMeshProUGUI>(true).gameObject.SetActive(false);
            myPurchaceBtns[batNo].GetComponentInChildren<Image>(true).gameObject.SetActive(false);

            purchaseTextObjects[batNo].SetActive(true);

            loadSceneShop.Purchase(batNo);

            FindObjectOfType<AudioManager>().Play("Button");
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemSO.Length; i++)
        {
            if (language.CurremtLanguage == "en")
            {
                storePanel[i].titleText.text = shopItemSO[i].titleEn;
                print("английский");
            }

            if (language.CurremtLanguage == "ru")
            {
                storePanel[i].titleText.text = shopItemSO[i].titleRu;
                print("не английский");
            }
            storePanel[i].CostText.text = shopItemSO[i].baseCost.ToString();
        }
    }
}
