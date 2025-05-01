using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OneCombo", menuName = "Discount/OneCombo")]
public class OneCombo : DiscountRule
{
    [SerializeField] private List<ItemMenuSO> _itemsCombo;

    public override DiscountStruct GetDiscount(Client client, OrderStruct order)
    {
        DiscountStruct discount = BaseStruct();

        List<string> requiredIDs = new();
        foreach (var item in _itemsCombo)
            requiredIDs.Add(item.ItemID);

        List<string> orderIDs = new();
        foreach (var menuItem in order.MenuItems)
            orderIDs.Add(menuItem.GetDescription());

        bool allItemsPresent = requiredIDs.TrueForAll(id => orderIDs.Contains(id));

        if (allItemsPresent)
        {
            discount.Description = p_description + string.Join(", ", requiredIDs);

            discount.Discount = order.FullPrice * (p_percentegeDiscount / 100f);
        }

        return discount;
    }
}
