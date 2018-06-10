using FitnessApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessApp.Repository
{
    public static class TrainerRepo
    {
        public static List<Trainer> Trainers = new List<Trainer>
        {
            new Trainer { Id = 1, FullName = "Ana Popovska", Phone = "078144545", Email = "pss@hotmail.com", Biography = "first biography", Photo = "~/Images/Trainers/1.jpg" },
            new Trainer { Id = 2, FullName = "Petar Angelovski", Phone = "078276785", Email = "vss@hotmail.com", Biography = "second biography", Photo = "~/Images/Trainers/2.jpg" },
            new Trainer { Id = 3, FullName = "Viktor Blazevski", Phone = "078382565", Email = "tss@hotmail.com", Biography = "third biography", Photo = "~/Images/Trainers/3.jpg" },
        };

        public static List<TrainingType> TrainingTypes = new List<TrainingType>
        {
            new TrainingType { Id = 1, Name = "Aerobik", Description = "first description", Photo = "~/Images/TrainingTypes/1.jpg", TrainerId = 1  },
            new TrainingType { Id = 2, Name = "Fitness", Description = "second description", Photo = "~/Images/TrainingTypes/2.jpg", TrainerId = 2 },
            new TrainingType { Id = 3, Name = "Body building", Description = "third description", Photo = "~/Images/TrainingTypes/3.jpg", TrainerId = 3 },
        };

        public static List<Schedule> Schedules = new List<Schedule>
        {
            new Schedule { Id = 1, DayOfWeekId = 1, StartTimeId = 1, EndTimeId = 2, TrainingTypeId = 1 },
            new Schedule { Id = 2, DayOfWeekId = 2, StartTimeId = 2, EndTimeId = 3, TrainingTypeId = 2 },
            new Schedule { Id = 3, DayOfWeekId = 3, StartTimeId = 3, EndTimeId = 4, TrainingTypeId = 3 },
        };

        public static List<DaysOfWeek> DaysOfWeek = new List<DaysOfWeek>
        {
            new DaysOfWeek{Id = 1, Day = Days.Monday.ToString()},
            new DaysOfWeek{Id = 2, Day = Days.Tuesday.ToString()},
            new DaysOfWeek{Id = 3, Day = Days.Wednesday.ToString()},
            new DaysOfWeek{Id = 4, Day = Days.Thursday.ToString()},
            new DaysOfWeek{Id = 5, Day = Days.Friday.ToString()},
            new DaysOfWeek{Id = 6, Day = Days.Saturday.ToString()},
            new DaysOfWeek{Id = 7, Day = Days.Sunday.ToString()}
        };

        public static List<HoursOfDay> Hours = new List<HoursOfDay>
        {
            new HoursOfDay{Id = 1, Hour = "10:00"},
            new HoursOfDay{Id = 2, Hour = "11:00"},
            new HoursOfDay{Id = 3, Hour = "12:00"},
            new HoursOfDay{Id = 4, Hour = "13:00"},
            new HoursOfDay{Id = 5, Hour = "14:00"},
            new HoursOfDay{Id = 6, Hour = "15:00"},
            new HoursOfDay{Id = 7, Hour = "16:00"},
            new HoursOfDay{Id = 8, Hour = "17:00"},
            new HoursOfDay{Id = 9, Hour = "18:00"},
            new HoursOfDay{Id = 10, Hour = "19:00"},
            new HoursOfDay{Id = 11, Hour = "20:00"},
            new HoursOfDay{Id = 12, Hour = "21:00"},
            new HoursOfDay{Id = 13, Hour = "22:00"},
        };

    }
};
