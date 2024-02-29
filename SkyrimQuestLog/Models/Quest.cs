namespace SkyrimQuestLog.Models
{
    public class Quest
    {
        public int QuestId { get; set; }
        public string QuestName { get; set; }
        public string QuestDescription { get; set; }
        public string QuestType { get; set; }
        public string Location { get; set; }
        public string Reward { get; set; }
        public string[] Walkthrough { get; set; }
        public bool IsCompleted { get; set; }
    }
}
