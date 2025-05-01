using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDecorator : Food
{
    protected Food p_food;
    private string _decoratorItem = "Decorator";
    private float _addPrice = 1f;

    public FoodDecorator(Food food)
    {
        p_food = food;
    }

    public void SetDecoratorItemName(string name) => _decoratorItem = name;
    public void SetPriceDecorator(float price) => _addPrice = price;

    public override string GetDescription()
    {
        return p_food.GetDescription() + ", " + _decoratorItem;
    }

    public override float GetPrice()
    {
        return p_food.GetPrice() + _addPrice;
    }
}
