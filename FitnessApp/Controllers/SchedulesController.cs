using FitnessApp.Models;
using FitnessApp.Repository;
using FitnessApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web.Mvc;

namespace FitnessApp.Controllers
{
    public class SchedulesController : Controller
    {       
        public ViewResult ListAll()
        {
            List<Schedule> schedules = TrainerRepo.Schedules;
            List<TrainingType> trainings = TrainerRepo.TrainingTypes;
            List<Trainer> trainers = TrainerRepo.Trainers;
            List<HoursOfDay> hours = TrainerRepo.Hours;
            List<DaysOfWeek> daysOfWeek = TrainerRepo.DaysOfWeek;

            var viewModel = new ScheduleTrainingTrainerViewModel
            {
                Trainers = trainers,
                TrainingTypes = trainings,
                Schedules = schedules,
                Hours = hours,
                DaysOfWeek = daysOfWeek
            };
            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Schedule schedule = TrainerRepo.Schedules.Single(x => x.Id == id);
            List<TrainingType> trainings = TrainerRepo.TrainingTypes;
            List<Trainer> trainers = TrainerRepo.Trainers;

            var viewModel = new ScheduleTypeTrainer
            {
                Trainers = trainers,
                TrainingTypes = trainings,
                Schedule = schedule
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CreateScheduleViewModel
            {
                Hours = TrainerRepo.Hours,
                DaysOfWeek = TrainerRepo.DaysOfWeek,
                TrainingTypes = TrainerRepo.TrainingTypes,
            };            
            return View(viewModel);            
        }

        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CreateScheduleViewModel
                {
                    Hours = TrainerRepo.Hours,
                    DaysOfWeek = TrainerRepo.DaysOfWeek,
                    TrainingTypes = TrainerRepo.TrainingTypes,
                    Schedule = schedule
                };
                return View(viewModel);
            }
            else
            {   
                TrainerRepo.Schedules.Add(schedule);
                return RedirectToAction("ListAll");
            } 
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Schedule schedule = TrainerRepo.Schedules.Single(x => x.Id == id);
            var viewModel = new CreateScheduleViewModel
            {
                Hours = TrainerRepo.Hours,
                DaysOfWeek = TrainerRepo.DaysOfWeek,
                TrainingTypes = TrainerRepo.TrainingTypes,
                Schedule = schedule
            };            
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View("Edit", viewModel);
        }
        [HttpPost]
        public ActionResult Edit(CreateScheduleViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                Schedule schedule = TrainerRepo.Schedules.Single(x => x.Id == viewModel.Schedule.Id);
                var newViewModel = new CreateScheduleViewModel
                {
                    Hours = TrainerRepo.Hours,
                    DaysOfWeek = TrainerRepo.DaysOfWeek,
                    TrainingTypes = TrainerRepo.TrainingTypes,
                    Schedule = schedule
                };                
                return View(newViewModel);
            }

            int index = TrainerRepo.Schedules.FindIndex(t => t.Id == viewModel.Schedule.Id);
            Schedule newSchedule = viewModel.Schedule;
            
            TrainerRepo.Schedules.RemoveAt(index);
            TrainerRepo.Schedules.Insert(index, newSchedule);

            return RedirectToAction("ListAll");
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int index = TrainerRepo.Schedules.FindIndex(t => t.Id == id);
            TrainerRepo.Schedules.RemoveAt(index);

            return RedirectToAction("ListAll");
        }
    }
}