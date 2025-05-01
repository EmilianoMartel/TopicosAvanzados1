public class Food : MenuItem
{
    public Food()
    {
    }

    public void SetItemName(string name) => p_itemName = name;
    public void SetPrice(float price) => p_price = price;
}