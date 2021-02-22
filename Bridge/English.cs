using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp_projekt.Bridge
{
    class English : ILanguage
    {
        public string GetQuestionContent(Question question)
        {
            return question.GetContentPolish();
        }

        public bool CheckAnswer(Question question, string answer)
        {
            if (question.CheckAnswerEnglish(answer))
                return true;
            else
                return false;
        }

        public string GetQuestionAnswer(Question question)
        {
            return question.GetAnswerEnglish();
        }

        public List<string> GetWrongAnswers(Question question)
        {
            return question.WrongAnswersEnglish;
        }
    }
}
