using System;
using TMPro;
using UnityEngine;

public class UI_MONEYDISPLAY : MonoBehaviour
{
    public MoneyComponent MoneyComponent;
    public TextMeshProUGUI textComponent;

    void Awake()
    {
        MoneyComponent.OnMoneyChanged += OnMoneyChaged;
        MoneyComponent.OnMoneyInitialez += OnMonyInitialized;
    }

    private void OnMonyInitialized(float Money)
    {

        textComponent.text = Money.ToString();
    }
    private void OnMoneyChaged(float newMoney, float amountChanged)
    {
       
        textComponent.text = newMoney.ToString();


    }




}
   
