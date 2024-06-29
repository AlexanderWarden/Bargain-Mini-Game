using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHasMoney : MonoBehaviour
{
    public float Money;

    public TextMeshProUGUI MoneyText;

    private void Update()
    {
        MoneyText.text = Money.ToString();
    }
}
