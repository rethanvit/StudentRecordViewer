using StudentRecordViewer.DL;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentRecordViewerApp.Models
{
    public class StudentInputData
    {
        [Required]
        [Range(0, int.MaxValue)]
        public bool IsSuccessful { get; set; }
        public Student StudentData { get; set; }
        public string FeedbackMessage { get; set; }
    }
}
