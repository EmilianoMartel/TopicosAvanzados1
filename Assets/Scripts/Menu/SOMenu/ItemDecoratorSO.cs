using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDecoratorSO", menuName = "Data/ItemDecorator")]
public class ItemDecoratorSO : ScriptableObject
{
    [SerializeField] private string _decoratorName = "Decorator";
    [SerializeField] private float _price = 1f;

    public string DecoratorShow()
    {
        return _decoratorName + ": +" + _price.ToString("F2");
    }

    public DrinkDecorator GetDrinkDecorator(Drink drink)
    {
        DrinkDecorator decorator = new(drink);
        decorator.SetPriceDecorator(_price);
        decorator.SetDecoratorItemName(_decoratorName);

        return decorator;
    }

    public FoodDecorator GetFoodDecorator(Food food)
    {
        FoodDecorator decorator = new(food);
        decorator.SetPriceDecorator(_price);
        decorator.SetDecoratorItemName(_decoratorName);

        return decorator;
    }

}
