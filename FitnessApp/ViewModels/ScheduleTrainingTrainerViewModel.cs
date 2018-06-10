using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.ViewModels
{
    public class ScheduleTrainingTrainerViewModel
    {
        public List<Trainer> Trainers { get; set; }
        public List<TrainingType> TrainingTypes { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<HoursOfDay> Hours { get; set; }
        public List<DaysOfWeek> DaysOfWeek { get; set; }
    }
}