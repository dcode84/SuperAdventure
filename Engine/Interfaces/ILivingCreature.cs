namespace Engine
{
    public interface ILivingCreature
    {
        int CurrentHitPoints { get; set; }
        int MaximumHitPoints { get; set; }
        int Strength { get; set; }
        int Intelligence { get; set; }
        int Vitality { get; set; }
    }
}