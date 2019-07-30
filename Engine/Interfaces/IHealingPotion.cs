namespace Engine
{
    public interface IHealingPotion : IItem
    {
        int AmountToHeal { get; set; }
        new int ID { get; set; }
        new string Name { get; set; }
        new string NamePlural { get; set; }
    }
}