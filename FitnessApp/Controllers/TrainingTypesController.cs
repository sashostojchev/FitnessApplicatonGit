using FitnessApp.Models;
using FitnessApp.Repository;
using FitnessApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FitnessApp.Controllers
{
    public class TrainingTypesController : Controller
    {
        // GET: TrainingTypes
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult ListAll()
        {
            List<TrainingType> trainingTypes = TrainerRepo.TrainingTypes;
            List<Trainer> trainers = TrainerRepo.Trainers;

            var viewModel = new TrainingTypeTrainerViewModel
            {
                Trainers = trainers,
                TrainingTypes = trainingTypes
            };

            return View(viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            TrainingType trainingType = TrainerRepo.TrainingTypes.Single(x => x.Id == id);
            List<Trainer> trainers = TrainerRepo.Trainers;

            var viewModel = new TrainingTrainersViewModel
            {
                Trainers = trainers,
                Id = trainingType.Id,
                Name = trainingType.Name,
                Description = trainingType.Description,
                Photo = trainingType.Photo,
                PhotoUpload = trainingType.PhotoUpload,
                TrainerId = trainingType.TrainerId
            };
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new TrainingTrainersViewModel
            {
                Trainers = TrainerRepo.Trainers,
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(TrainingType trainingType)
        {
            var viewModel = new TrainingTrainersViewModel
            {
                Trainers = TrainerRepo.Trainers,
                Id = trainingType.Id,
                Name = trainingType.Name,
                Description = trainingType.Description,
                Photo = trainingType.Photo,
                PhotoUpload = trainingType.PhotoUpload,
                TrainerId = trainingType.TrainerId
            };
            if (!ModelState.IsValid)
                return View(viewModel);
            else
            {
                if (trainingType.PhotoUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(trainingType.PhotoUpload.FileName);
                    string extension = Path.GetExtension(trainingType.PhotoUpload.FileName);
                    fileName = trainingType.Name + "_" + DateTime.Now.ToString("dd-MM-yy hh-mm-ss") + extension;
                    trainingType.Photo = "~/Images/TrainingTypes/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Images/TrainingTypes/"), fileName);
                    trainingType.PhotoUpload.SaveAs(fileName);
                }
                trainingType.Trainer = TrainerRepo.Trainers.Single(x => x.Id == trainingType.TrainerId);
                TrainerRepo.TrainingTypes.Add(trainingType);
                return RedirectToAction("ListAll");
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            TrainingType trainingType = TrainerRepo.TrainingTypes.Single(x => x.Id == id);
            var viewModel = new TrainingTrainersViewModel
            {
                Trainers = TrainerRepo.Trainers,
                Id = trainingType.Id,
                Name = trainingType.Name,
                Description = trainingType.Description,
                Photo = trainingType.Photo,
                PhotoUpload = trainingType.PhotoUpload,
                TrainerId = trainingType.TrainerId
            };
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);            

            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TrainingTrainersViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                TrainingType trainingType = TrainerRepo.TrainingTypes.Single(x => x.Id == viewModel.Id);
                var newViewModel = new TrainingTrainersViewModel
                {
                    Trainers = TrainerRepo.Trainers,
                    Id = trainingType.Id,
                    Name = trainingType.Name,
                    Description = trainingType.Description,
                    Photo = trainingType.Photo,
                    PhotoUpload = trainingType.PhotoUpload,
                    TrainerId = trainingType.TrainerId
                };
                return View(newViewModel);
            }

            int index = TrainerRepo.TrainingTypes.FindIndex(t => t.Id == viewModel.Id);

            if (viewModel.PhotoUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(viewModel.PhotoUpload.FileName);
                string extension = Path.GetExtension(viewModel.PhotoUpload.FileName);
                fileName = viewModel.Name + "_" + DateTime.Now.ToString("dd-MM-yy hh-mm-ss") + extension;
                viewModel.Photo = "~/Images/TrainingTypes/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Images/TrainingTypes/"), fileName);
                viewModel.PhotoUpload.SaveAs(fileName);
            }
            else
                viewModel.Photo = TrainerRepo.TrainingTypes.Single(x => x.Id == viewModel.Id).Photo;

            TrainingType training = new TrainingType
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Photo = viewModel.Photo,
                PhotoUpload = viewModel.PhotoUpload,
                TrainerId = viewModel.TrainerId
            };
            TrainerRepo.TrainingTypes.RemoveAt(index);
            TrainerRepo.TrainingTypes.Insert(index, training);

            return RedirectToAction("ListAll");
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int index = TrainerRepo.TrainingTypes.FindIndex(t => t.Id == id);
            TrainerRepo.TrainingTypes.RemoveAt(index);

            return RedirectToAction("ListAll");
        }
    }
}