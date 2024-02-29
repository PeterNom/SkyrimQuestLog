using Microsoft.EntityFrameworkCore;
using SkyrimQuestLog.Data;
using SkyrimQuestLog.Models;

namespace SkyrimQuestLog.Repositories
{
    public class QuestRepository : IQuestRepository
    {
        private readonly SkyrimQuestLogDb _skyrimQuestLogDb;

        public QuestRepository(SkyrimQuestLogDb skyrimQuestLogDb)
        {
            _skyrimQuestLogDb = skyrimQuestLogDb;
        }

        public async Task<IEnumerable<Quest>> AllQuests()
        {
            return await _skyrimQuestLogDb.Quests.OrderBy(q => q.QuestId).AsNoTracking().ToListAsync();
        }

        public async Task<Quest?> GetQuestById(int id)
        {
            return await _skyrimQuestLogDb.Quests.AsNoTracking().FirstOrDefaultAsync(q => q.QuestId == id);
        }

        public async Task<IEnumerable<Quest>> GetQuestByName(string questName)
        {
            if(!string.IsNullOrEmpty(questName))
            {
                return await _skyrimQuestLogDb.Quests.Where(q => q.QuestName.Contains(questName)).AsNoTracking().ToListAsync();
            }
            else
            {
                return Enumerable.Empty<Quest>();
            }
        }

        public async Task<IEnumerable<Quest>> SearchQuests(string searchQuery)
        {
            var result = from p in _skyrimQuestLogDb.Quests select p;

            if(!string.IsNullOrEmpty(searchQuery))
            {
                result = result.Where(q => q.QuestName == searchQuery);
            }

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Quest>> GetQuestsPagedAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    
        public async Task<int> AddQuestAsync(Quest quest)
        {
            _skyrimQuestLogDb.Quests.Add(quest);
            return await _skyrimQuestLogDb.SaveChangesAsync();
        }
    }
}
