namespace Engine
{
    public interface IWeapon : IItem
    {
        new int ID { get; set; }
        int MaximumDamage { get; set; }
        int MinimumDamage { get; set; }
        new string Name { get; set; }
        new string NamePlural { get; set; }
    }
}