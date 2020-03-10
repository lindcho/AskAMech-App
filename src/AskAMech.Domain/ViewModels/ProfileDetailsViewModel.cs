﻿using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Domain.Models;

namespace AskAMech.Domain.ViewModels
{
   public class ProfileDetailsViewModel
    {
        public  ApplicationUser User { get; set; }
        public IEnumerable<Question> AskedQuestions { get; set; }
        public IEnumerable<AnswersListViewModel> QuestionAnswers { get; set; }
    }
}
