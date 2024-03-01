using Microsoft.EntityFrameworkCore;
using SkyrimQuestLog.Data;
using SkyrimQuestLog.Models;
using SkyrimQuestLog.ViewModels;

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

        public async Task<int> DeleteAppointmentAsync(int id)
        {
            var quest = await _skyrimQuestLogDb.Quests.FirstOrDefaultAsync(q => q.QuestId == id);

            if(quest != null)
            {
                _skyrimQuestLogDb.Quests.Remove(quest);
                return await _skyrimQuestLogDb.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The quest to delete could not be found");
            }
        }

        public async Task<int> UpdateQuest(QuestAddViewModel questAddViewModel)
        {
            var questToUpdate = await _skyrimQuestLogDb.Quests.FirstOrDefaultAsync(q => q.QuestId == questAddViewModel.Quest.QuestId);

            if(questToUpdate != null)
            {
                questToUpdate.QuestName = questAddViewModel.Quest.QuestName;
                questToUpdate.QuestId = questAddViewModel.Quest.QuestId;
                questToUpdate.Walkthrough = questAddViewModel.Quest.Walkthrough;
                questToUpdate.Reward = questAddViewModel.Quest.Reward;
                questToUpdate.QuestDescription = questAddViewModel.Quest.QuestDescription;
                questToUpdate.IsCompleted = questAddViewModel.Quest.IsCompleted;

                questToUpdate.Cities = questAddViewModel.Quest.Cities;
                questToUpdate.Faction = questAddViewModel.Quest.Faction;
                questToUpdate.Settlements = questAddViewModel.Quest.Settlements;
                questToUpdate.OrcStringholds = questAddViewModel.Quest.OrcStringholds;

                questToUpdate.Main = questAddViewModel.Quest.Main;
                questToUpdate.Mischellaneous = questAddViewModel.Quest.Mischellaneous;
                questToUpdate.Other = questAddViewModel.Quest.Other;
                questToUpdate.Towns = questAddViewModel.Quest.Towns;

                _skyrimQuestLogDb.Quests.Update(questToUpdate);
                return await _skyrimQuestLogDb.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"The quest you try to update doesn't seem to exist.");
            }
        }
    
        
    }
}
