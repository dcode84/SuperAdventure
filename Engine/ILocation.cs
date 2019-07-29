namespace Engine
{
    public interface ILocation
    {
        string Description { get; set; }
        int ID { get; set; }
        IItem ItemRequiredToEnter { get; set; }
        ILocation LocationToEast { get; set; }
        ILocation LocationToNorth { get; set; }
        ILocation LocationToSouth { get; set; }
        ILocation LocationToWest { get; set; }
        Monster MonsterLivingHere { get; set; }
        string Name { get; set; }
        Quest QuestAvailableHere { get; set; }
    }
}