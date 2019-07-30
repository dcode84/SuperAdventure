namespace Engine
{
    public interface IQuestCompletionItem
    {
        IItem Item { get; set; }
        int Quantity { get; set; }
    }
}