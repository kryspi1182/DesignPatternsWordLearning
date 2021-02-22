using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ztp_projekt
{
    public class ParentPage : Page
    {
        protected static List<Question> questions = new List<Question>();
        protected QuestionData QuestionData = new QuestionData();
        protected static MainPage MainPage;
        protected static Study StudyPageEnglish;
        protected static Study StudyPagePolish;
        protected static int LanguageSetting = 0;
        protected static int UndoSetting = 0;

        public ParentPage()
        {
            questions = QuestionData.GetQuestions();
        }
    }
}
