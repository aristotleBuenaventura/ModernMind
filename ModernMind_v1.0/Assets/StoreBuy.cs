using UnityEngine;
using TMPro;

public class StoreBuy : MonoBehaviour
{
    public int price;   // how much the item costs
    public int stock;   // how many items available
    public GameObject buyButton, noStock, noMoney;
    public TextMeshProUGUI stockText, stockBought; // reference to your stock text UI
    public string PowerType;  // unique key for PlayerPrefs

    private int boughtCount = 0; // number of items bought

    private void Start()
    {
        // Load previously bought count
        boughtCount = PlayerPrefs.GetInt(PowerType, 0);
        UpdateStockText();
        UpdateBoughtText();
    }

    public void Buy()
    {
        int currentCoins = CoinsValue.Instance.GetScore();

        if (stock <= 0)
        {
            buyButton.SetActive(false);
            noStock.SetActive(true);
            return;
        }

        if (currentCoins < price)
        {
            noMoney.SetActive(true);
            return;
        }

        // Deduct coins and stock
        CoinsValue.Instance.DecrementScore(price);
        stock--;
        boughtCount++;

        // Save bought count in PlayerPrefs
        PlayerPrefs.SetInt(PowerType, boughtCount);
        PlayerPrefs.Save();

        UpdateStockText();
        UpdateBoughtText();

        // If stock is now zero, disable buy button
        if (stock <= 0)
        {
            buyButton.SetActive(false);
            noStock.SetActive(true);
        }
    }

    private void UpdateStockText()
    {
        if (stockText != null)
        {
            stockText.text = "x" + stock + " Stock";
        }
    }

    private void UpdateBoughtText()
    {
        if (stockBought != null)
        {
            stockBought.text = "x" + boughtCount;
        }
    }
}
