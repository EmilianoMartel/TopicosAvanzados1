using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Food,
    Drink
}

[CreateAssetMenu(fileName = "ItemMenuSO", menuName = "Data/ItemMenu")]
public class ItemMenuSO : ScriptableObject
{
    [SerializeField] private string _itemID = "Item";
    [SerializeField] private ItemType _type;
    [SerializeField] private float _price = 5f;
    [Tooltip("Put the Decorators could go with this itemMenu")]
    [SerializeField] private List<ItemDecoratorSO> _itemDecorators;

    public string ItemID {  get { return _itemID; } }
    public List<ItemDecoratorSO> ItemDecorators { get { return _itemDecorators; } }
    public MenuItem GetMenuItem()
    {
        MenuItem returnItem = null;

        switch (_type)
        {
            case ItemType.Food:
                Food food = new();
                food.SetItemName(_itemID);
                food.SetPrice(_price);

                returnItem = food;
                break;
            case ItemType.Drink:
                Drink drink = new();
                drink.SetItemName(_itemID);
                drink.SetPrice(_price);

                returnItem = drink;
                break;
            default:
                break;
        }

        return returnItem;
    }
}