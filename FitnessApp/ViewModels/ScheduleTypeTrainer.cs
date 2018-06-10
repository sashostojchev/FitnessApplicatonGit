using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.ViewModels
{
    public class ScheduleTypeTrainer
    {
        public List<Trainer> Trainers { get; set; }
        public List<TrainingType> TrainingTypes { get; set; }
        public Schedule Schedule { get; set; }
    }
}