using System;
using UnityEngine;

public abstract class DiscountRule : ScriptableObject
{
    [SerializeField] protected string p_description = "Discount";
    [Tooltip("Mark Percentege discount")]
    [Range(0, 100)]
    [SerializeField] protected float p_percentegeDiscount = 0;
    public virtual DiscountStruct GetDiscount(Client client, OrderStruct order)
    {
        return BaseStruct();
    }

    protected DiscountStruct BaseStruct()
    {
        DiscountStruct discount = new();
        discount.Description = "";
        return discount;
    }
}

[Serializable]
public struct DiscountStruct
{
    public string Description;
    public float Discount;
}
