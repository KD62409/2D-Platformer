using System;
using System.Collections;
using UnityEngine;

public class MoneyComponent : MonoBehaviour
{
    
    public int Money = 1;
    private float currentMoney;
    
    public delegate void OnMoneyChangedHandler(float newMoney, float amountChanged);
    public event OnMoneyChangedHandler OnMoneyChanged;
    public delegate void OnMoneyInitializedHandler(float Money);
    public event OnMoneyInitializedHandler OnMoneyInitialez;
    private void Start()
    {
        currentMoney = Money;
        OnMoneyInitialez?.Invoke(currentMoney);
    }


    public void AddMoney(float amount)
    {
        currentMoney += amount;
        OnMoneyChanged?.Invoke(currentMoney, amount);
       
    }
}