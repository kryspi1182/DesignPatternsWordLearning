using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp_projekt.Bridge
{
    class Polish : ILanguage
    {
        public string GetQuestionContent(Question question)
        {
            return question.GetContentEnglish();
        }

        public bool CheckAnswer(Question question, string answer)
        {
            if (question.CheckAnswerPolish(answer))
                return true;
            else
                return false;
        }

        public string GetQuestionAnswer(Question question)
        {
            return question.GetAnswerPolish();
        }

        public List<string> GetWrongAnswers(Question question)
        {
            return question.WrongAnswersPolish;
        }
    }
}
