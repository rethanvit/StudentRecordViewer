using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SutdentRecordViewer.BL
{
    public static class Constants
{
        public const string InvalidStudentIdMessage = "Please provide a valid student ID";
        public const string NonExistentStudent = "No record found for the student ID provided.";

        public static int TotalCreditsAllowed = 160;
    }
}
