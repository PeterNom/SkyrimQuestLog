using Microsoft.AspNetCore.Mvc.Rendering;
using SkyrimQuestLog.Models;

namespace SkyrimQuestLog.ViewModels
{
    public class QuestAddViewModel
    {
        public Quest Quest { get; set; } = default!;
    }
}
