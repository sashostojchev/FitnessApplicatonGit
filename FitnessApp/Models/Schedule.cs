using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Models
{
    public class Schedule
    {
        [Required]
        public int Id { get; set; }

        public string DayOfWeek { get; set; }

        [Required]
        [Display(Name = "Day of Week")]
        public int DayOfWeekId { get; set; }
        
        public string StartTime { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public int StartTimeId { get; set; }
        
        public string EndTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public int EndTimeId { get; set; }

        public TrainingType TrainingType { get; set; }

        [Required]
        [Display(Name = "Training Type")]
        public int TrainingTypeId { get; set; }
    }

    public enum Days
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }   
}