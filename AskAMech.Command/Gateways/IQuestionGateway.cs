using System;
using System.Collections.Generic;
using System.Text;
using AskAMech.Domain.Models;

namespace AskAMech.Command.Gateways
{
   public interface IQuestionGateway
   {
       List<Question> GetAllQuestions();
   }
}
