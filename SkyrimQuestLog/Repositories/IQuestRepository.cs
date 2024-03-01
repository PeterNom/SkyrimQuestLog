using SkyrimQuestLog.Models;
using SkyrimQuestLog.ViewModels;

namespace SkyrimQuestLog.Repositories
{
    public interface IQuestRepository
    {
        Task<IEnumerable<Quest>> AllQuests();
        Task<Quest?> GetQuestById(int id);
        Task<IEnumerable<Quest>> GetQuestByName(string questName);
        Task<IEnumerable<Quest>> SearchQuests(string searchQuery);
        Task<IEnumerable<Quest>> GetQuestsPagedAsync(int pageNumber, int pageSize);
        Task<int> AddQuestAsync(Quest quest);
        Task<int> DeleteAppointmentAsync(int id);
        Task<int> UpdateQuest(QuestAddViewModel questAddViewModel);
    }
}
