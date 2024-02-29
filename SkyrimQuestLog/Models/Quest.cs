using SkyrimQuestLog.Models.Enumerators.Locations;
using SkyrimQuestLog.Models.Enumerators.QuestTypes;
using System.ComponentModel.DataAnnotations;

namespace SkyrimQuestLog.Models
{
    public class Quest
    {
        public int QuestId { get; set; }

        [Display(Name = "Quest Name")]
        [Required]
        public string QuestName { get; set; } = default!;

        [StringLength(100)]
        [Display(Name = "Quest description")]
        public string QuestDescription { get; set; } = default!;

        public Faction Faction { get; set; }
        public Main Main { get; set; }
        public Mischellaneous Mischellaneous { get; set; }
        public Other Other { get; set; }
        public City Cities { get; set; }
        public Town Towns { get; set; }
        public Settlement Settlements { get; set; }
        public OrcStringhold OrcStringholds { get; set; }

        [Display(Name = "Reward")]
        [Required]
        public string Reward { get; set; } = default!;

        public string[] Walkthrough { get; set; } = default!;
        public bool IsCompleted { get; set; } = false;
    }
}
