using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dice_Object : MonoBehaviour
{
    public int Value = 0;
    public bool IsOddNumber;

    public int IndicatorValue = 0;
    public GameObject IndicatorObject;

    public TextMeshProUGUI ValueText;

    private void Update()
    {

        ValueText.text = Value.ToString();

        if (IndicatorValue == 1)
        {
            IndicatorObject.SetActive(true);
            IndicatorObject.GetComponent<Image>().color = new Color(0, 255, 0, 255);
        }
        else if(IndicatorValue == 2)
        {
            IndicatorObject.SetActive(true);
            IndicatorObject.GetComponent<Image>().color = new Color(255, 0, 0, 255);
        }
        else
        {
            IndicatorObject.SetActive(false);
        }
    }

    public void GetRandomValue()
    {
        Value = Random.Range(1, 7);
        
        CheckIfOdd(Value);
    }

    public void CheckIfOdd(int value)
    {
        if (value == 1 || value == 3 || value == 5)
            IsOddNumber = true;
        else
            IsOddNumber = false;
    }
}
