using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ztp_projekt.Bridge
{
    public interface ILanguage
    {
        string GetQuestionContent(Question question);
        bool CheckAnswer(Question question, string answer);
        string GetQuestionAnswer(Question question);
        List<string> GetWrongAnswers(Question question);
    }
}
