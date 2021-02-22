using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp_projekt
{
    public class Question
    {
        private int Id;
        private string ContentEnglish;
        private string ContentPolish;
        private string AnswerEnglish;
        private string AnswerPolish;

        public List<string> WrongAnswersPolish;
        public List<string> WrongAnswersEnglish;

        public Question() { }

        public Question(int id, string contentEnglish, string contentPolish, string answerEnglish, string answerPolish)
        {
            Id = id;
            ContentEnglish = contentEnglish;
            ContentPolish = contentPolish;
            AnswerEnglish = answerEnglish;
            AnswerPolish = answerPolish;
        }

        public Question(int id, string contentEnglish, string contentPolish, string answerEnglish, string answerPolish, List<string> wrongAnswersPolish, List<string> wrongAnswersEnglish)
        {
            Id = id;
            ContentEnglish = contentEnglish;
            ContentPolish = contentPolish;
            AnswerEnglish = answerEnglish;
            AnswerPolish = answerPolish;
            WrongAnswersPolish = wrongAnswersPolish;
            WrongAnswersEnglish = wrongAnswersEnglish;
        }

        
        public int GetId()
        {
            return Id;
        }
        public bool CheckAnswerEnglish(string answer)
        {
            if (answer == AnswerEnglish)
                return true;
            return false;
        }

        public bool CheckAnswerPolish(string answer)
        {
            if (answer == AnswerPolish)
                return true;
            return false;
        }

        public string GetContentEnglish()
        {
            return ContentEnglish;
        }

        public string GetContentPolish()
        {
            return ContentPolish;
        }

        public string GetAnswerEnglish()
        {
            return AnswerEnglish;
        }

        public string GetAnswerPolish()
        {
            return AnswerPolish;
        }

        public override string ToString()
        {
            return ContentPolish + " | " + ContentEnglish;
        }
    }
}
