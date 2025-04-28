using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MenuItem
{
    public Coffee()
    {
        p_itemName = "Coffee";
        p_price = 5f;
    }
}

public class DecaffeinatedCoffee : MenuItem
{
    public DecaffeinatedCoffee()
    {
        p_itemName = "Decaffeinated Coffee";
        p_price = 10f;
    }
}