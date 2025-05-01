public class DrinkDecorator : Drink
{
    protected Drink p_drink;
    private string _decoratorItem = "Decorator";
    private float _addPrice = 1f;

    public DrinkDecorator(Drink drink)
    {
        p_drink = drink;
    }

    public void SetDecoratorItemName(string name) => _decoratorItem = name;
    public void SetPriceDecorator(float price) => _addPrice = price;

    public override string GetDescription()
    {
        return p_drink.GetDescription() + ", " + _decoratorItem;
    }

    public override float GetPrice()
    {
        return p_drink.GetPrice() + _addPrice;
    }
}
