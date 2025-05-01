using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuItem
{
    protected string p_itemName = "MenuItem";
    protected float p_price = 5f;

    public virtual string GetDescription()
    {
        return p_itemName;
    }

    public virtual float GetPrice()
    {
        return p_price;
    }
}
