public class Item
{
    public string itemName;
    public int itemProbability; //total = 100 where item1 = 50, item2 = 30, item3 = 20
    public int startAngle; //item1 = (0,10), (50,60) item2 =(11, 30)
    public int endAngle;
    public int itemAmount;

    public Item(string itemName, int itemProbability, int startAngle, int endAngle, int itemAmount)
    {
        this.itemName = itemName;
        this.itemProbability = itemProbability;
        this.startAngle = startAngle;
        this.endAngle = endAngle;
        this.itemAmount = itemAmount;
    }
}
