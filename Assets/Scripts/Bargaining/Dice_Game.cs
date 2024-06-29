using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dice_Game : MonoBehaviour
{
    private Item_Price itemPrice;

    public List<GameObject> Dices = new List<GameObject>();

    public int WhatPlayerChoosen = 0;
    public bool PlayerHasChoosen = false;

    public GameObject OddsButtonChoosen;
    public GameObject EvenButtonChoosen;

    public GameObject EndGameObject;
    public TextMeshProUGUI EndGameText;
    public TextMeshProUGUI EndGameCountText;

    public int PlayerWonNumber = 0;
    public int MerchantWonNumber = 0;

    public GameObject PlusOneButtonObj;
    public GameObject DoubleButtonObj;

    private void Start()
    {
        itemPrice = FindObjectOfType<Item_Price>();
    }

    public void StartTheMiniGame()
    {
        if (PlayerHasChoosen)
        {
            RollTheDices();
        }
    }

    //Start the dice game
    private void RollTheDices()
    {
        for (int i = 0; i < Dices.Count; i++)
        {
            Dices[i].GetComponent<Dice_Object>().GetRandomValue();
            Debug.Log("Dice " + (i + 1) + " has value: " + Dices[i].GetComponent<Dice_Object>().Value);
        }

        CheckForOdds(WhatPlayerChoosen);
    }

    //Check for number of positive dices for player and merch
    private void CheckForOdds(int playerChoice)
    {
        for (int i = 0; i < Dices.Count; i++)
        {
            if (Dices[i].GetComponent<Dice_Object>().IsOddNumber)
            {
                if(playerChoice == 1)
                {
                    PlayerWonNumber++;
                    Dices[i].GetComponent<Dice_Object>().IndicatorValue = 1;
                }
                else
                {
                    MerchantWonNumber++;
                    Dices[i].GetComponent<Dice_Object>().IndicatorValue = 2;
                }
                
            }
            else
            {
                if (playerChoice == 2)
                {
                    PlayerWonNumber++;
                    Dices[i].GetComponent<Dice_Object>().IndicatorValue = 1;
                }
                else
                {
                    MerchantWonNumber++;
                    Dices[i].GetComponent<Dice_Object>().IndicatorValue = 2;
                }
            }

        }

        WhoIsWinner();
    }

    private void WhoIsWinner()
    {
        EndGameObject.SetActive(true);
        EndGameCountText.text = PlayerWonNumber + " - " + MerchantWonNumber;

        if (PlayerWonNumber > MerchantWonNumber)
        {
            EndGameText.text = "You have Won!";
            
            itemPrice.AddDiscount(true);

            DoubleButtonObj.SetActive(true);
        }
        else if (PlayerWonNumber < MerchantWonNumber)
        {
            EndGameText.text = "You have Lost!";
            itemPrice.AddDiscount(false);

            DoubleButtonObj.SetActive(true);
        }
        else if (PlayerWonNumber == MerchantWonNumber)
        {
            EndGameText.text = "Its a Tie!";
            PlusOneButtonObj.SetActive(true);
        }

    }

    private void ResetMiniGame()
    {
        EndGameObject.SetActive(false);
        PlusOneButtonObj.SetActive(false);
        DoubleButtonObj.SetActive(false);

        OddsButtonChoosen.SetActive(false);
        EvenButtonChoosen.SetActive(false);

        PlayerWonNumber = 0;
        MerchantWonNumber = 0;

        WhatPlayerChoosen = 0;
        PlayerHasChoosen = false;

        for (int i = 0; i < Dices.Count; i++)
        {
            Dices[i].GetComponent<Dice_Object>().Value = 0;
            Dices[i].GetComponent<Dice_Object>().IndicatorValue = 0;
        }
    }

    // Buttons
    public void PlayerChooseOdds()
    {
        WhatPlayerChoosen = 1;
        PlayerHasChoosen = true;

        OddsButtonChoosen.SetActive(true);
        EvenButtonChoosen.SetActive(false);
    }

    public void PlayerChooseEven()
    {
        WhatPlayerChoosen = 2;
        PlayerHasChoosen = true;

        OddsButtonChoosen.SetActive(false);
        EvenButtonChoosen.SetActive(true);
    }

    #region AfterBatchButtons

    public void PlusOneButton()
    {
        itemPrice.ItemDiscount += 1;
        ResetMiniGame();
    }

    public void DoubleButton()
    {
        itemPrice.ItemDiscount *= 2;
        ResetMiniGame();
    }

    #endregion

}
