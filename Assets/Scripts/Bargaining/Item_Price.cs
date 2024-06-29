using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Item_Price : MonoBehaviour
{
    private PlayerHasMoney playerMoney;

    public float ItemPrice;

    public float ItemDiscount;

    public TextMeshProUGUI ItemPriceText;
    public TextMeshProUGUI ItemDiscountText;

    private bool PlayerBoughtItem;
    private float ResetTime = 0;

    private void Start()
    {
        playerMoney = FindObjectOfType<PlayerHasMoney>();

    }

    private void Update()
    {
        ItemPriceText.text = ItemPrice.ToString();
        ItemDiscountText.text = ItemDiscount.ToString();

        if (PlayerBoughtItem)
        {
            ResetTime += Time.deltaTime;

            if(ResetTime >= 3)
            {
                Application.Quit();
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
        }

        if (ItemPrice <= 0)
            ItemPrice = 1;
    }

    public void AddDiscount(bool playerWon)
    {
        if (playerWon)
        {
            ItemPrice -= ItemDiscount;
            ItemPriceText.color = new Color(0, 255, 0, 255);
        }   
        else
        {
            ItemPrice += ItemDiscount;
            ItemPriceText.color = new Color(255, 0, 0, 255);
        }
            
    }

    public void BuyItem()
    {
        if(playerMoney.Money >= ItemPrice)
        {
            playerMoney.Money -= ItemPrice;
            PlayerBoughtItem = true;
        }
    }
}
