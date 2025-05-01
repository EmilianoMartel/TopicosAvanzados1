using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MemberDiscount", menuName = "Discount/Member")]
public class MemberDiscount : DiscountRule
{
    public override DiscountStruct GetDiscount(Client client, OrderStruct order)
    {
        DiscountStruct discount = BaseStruct();

        if (client.GetIsMember())
        {
            discount.Description = p_description;
            discount.Discount = order.FullPrice * (p_percentegeDiscount / 100f);
        }

        return discount;
    }
}
