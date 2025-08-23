using UnityEngine;
using TMPro;

public class StoreBuy : MonoBehaviour
{
    public int price;   // how much the item costs
    public int stock;   // how many items available
    public GameObject buyButton, noStock, noMoney;
    public TextMeshProUGUI stockText; // reference to your stock text UI


    private void Start()
    {
        UpdateStockText();
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

        UpdateStockText();

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
}
