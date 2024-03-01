using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SkyrimQuestLog.Repositories;
using SkyrimQuestLog.Models.Enumerators.Locations;
using SkyrimQuestLog.Models.Enumerators.QuestTypes;
using SkyrimQuestLog.ViewModels;
using SkyrimQuestLog.Models;

namespace SkyrimQuestLog.Controllers
{
    public class QuestController : Controller
    {
        private readonly IQuestRepository _questRepository;

        public QuestController(IQuestRepository questRepository)
        {
            _questRepository = questRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Quests";

            var quests = await _questRepository.AllQuests();

            return View(quests);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Title = "Quests Details";

            var quest = await _questRepository.GetQuestById(id);
            return View(quest);
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Quest Add";

            try
            {
                QuestAddViewModel questAddViewModel = new QuestAddViewModel();

                return View(questAddViewModel);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"There was an error: ${ex.Message}";
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(QuestAddViewModel questAddViewModel)
        {
            if(ModelState.IsValid)
            {
                Quest questNew = new()
                {
                    QuestId = questAddViewModel.Quest.QuestId,
                    QuestName = questAddViewModel.Quest.QuestName,
                    QuestDescription = questAddViewModel.Quest.QuestDescription,
                    Reward = questAddViewModel.Quest.Reward,
                    Walkthrough = questAddViewModel.Quest.Walkthrough,
                    IsCompleted = questAddViewModel.Quest.IsCompleted,
                    OrcStringholds = questAddViewModel.Quest.OrcStringholds,
                    Settlements = questAddViewModel.Quest.Settlements,
                    Towns = questAddViewModel.Quest.Towns,
                    Cities = questAddViewModel.Quest.Cities,
                    Other = questAddViewModel.Quest.Other,
                    Mischellaneous = questAddViewModel.Quest.Mischellaneous,
                    Main = questAddViewModel.Quest.Main,
                    Faction = questAddViewModel.Quest.Faction,
                };

                await _questRepository.AddQuestAsync(questNew);

                return RedirectToAction(nameof(Index));
            }

            return View(questAddViewModel);
        }
    
        public async Task<IActionResult> Delete(int id)
        {
            var quest = await _questRepository.GetQuestById(id);

            return View(quest);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if(id == null)
            {
                ViewData["ErrorMessage"] = "Deleting the quest failed, invalid id.";
                return View();
            }

            try
            {
                await _questRepository.DeleteAppointmentAsync(id.Value);
                TempData["QuestDeleted"] = "Quest deleted successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"Deleting the quest failed, please try again! Error: {ex.Message}";
            }

            var quest = await _questRepository.GetQuestById(id.Value);

            return View(quest);
        }
    
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quest = await _questRepository.GetQuestById(id.Value);

            var questModel = new QuestAddViewModel() { Quest= quest };

            return View(questModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(QuestAddViewModel questAddViewModel)
        {
            var questToUpdate = _questRepository.GetQuestById(questAddViewModel.Quest.QuestId);

            try
            {
                if(questToUpdate == null)
                {
                    ModelState.AddModelError(string.Empty, "The quest you want to update doesn't exist or was already deleted by someone else.");
                }
                if(ModelState.IsValid)
                {
                    await _questRepository.UpdateQuest(questAddViewModel);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Updating the quest failed, please try again! Error: {ex.Message}");
            }

            return View(questAddViewModel);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
