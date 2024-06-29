using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Discount_Slider : MonoBehaviour
{
    private Item_Price itemPrice;
    public Slider slider;

    private float doubleValue;

    private void Start()
    {
        itemPrice = FindObjectOfType<Item_Price>();

        SetMaxValue();
    }

    private void Update()
    {
        SetCurrentValue();

        if (itemPrice.ItemPrice >= doubleValue)
            itemPrice.ItemPrice = doubleValue - 1;
    }

    public void SetMaxValue()
    {
        doubleValue = itemPrice.ItemPrice * 2;
        slider.maxValue = doubleValue;

    }

    public void SetCurrentValue()
    {
        slider.value = itemPrice.ItemPrice;
    }
}
