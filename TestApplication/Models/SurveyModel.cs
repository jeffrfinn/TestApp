using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication.Models
{
    public class SurveyModel
    {
        public object UserId { get; set; }
        public object QuestionId { get; set; }

        public object Answer { get; set; }

        public object Comment { get; set; }
    }
}