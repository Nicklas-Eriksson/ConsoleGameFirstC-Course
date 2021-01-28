namespace Labb3.Items
{
    public interface IItem
    {
        string Name { get; set; }
        int GoldCost { get; set; }
        int GoldIfSold { get; set; }
        int ItemLevel { get; set; }
    }
}
