using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ztp_projekt.Models;

namespace ztp_projekt
{
    public class QuestionData
    {
        PytaniaDBContext PytaniaDBContext = PytaniaDBContext.GetDBContext();

        public List<Question> GetQuestions()
        {
            List<Question> result = new List<Question>();
            foreach(var x in PytaniaDBContext.Pytania)
            {
                result.Add(QuestionEntityToObject(x));
            }

            return result;
        }

        public Collection<Question> GetQuestionsCollection()
        {
            Collection<Question> result = new ObservableCollection<Question>();
            
            foreach(var x in PytaniaDBContext.Pytania)
            {
                result.Add(QuestionEntityToObject(x));
            }
            return result;
        }

        public int GetNextId()
        {
            return (int)PytaniaDBContext.Pytania.ToList().Max(tmp => tmp.IdPytania);
        }

        public void AddQuestion(Question question)
        {
            PytaniaDBContext.Pytania.Add(QuestionObjectToEntity(question));
            PytaniaDBContext.SaveChanges();
        }

        public void DeleteQuestion(Question question)
        {
            var tmp = PytaniaDBContext.Pytania.Where(x => x.IdPytania == question.GetId()).FirstOrDefault();
            PytaniaDBContext.Pytania.Remove(tmp);
            PytaniaDBContext.SaveChanges();
        }

        public void EditQuestion(Question question)
        {
            var tmp = PytaniaDBContext.Pytania.Where(x => x.IdPytania == question.GetId()).FirstOrDefault();

            tmp.TrescAngielski = question.GetContentEnglish();
            tmp.TrescPolski = question.GetContentPolish();

            tmp.OdpowiedzAngielski = question.GetAnswerEnglish();
            tmp.OdpowiedzPolski = question.GetAnswerPolish();

            tmp.BlednaOdpAngielski1 = question.WrongAnswersEnglish[0];
            tmp.BlednaOdpAngielski2 = question.WrongAnswersEnglish[1];
            tmp.BlednaOdpAngielski3 = question.WrongAnswersEnglish[2];

            tmp.BlednaOdpPolski1 = question.WrongAnswersPolish[0];
            tmp.BlednaOdpPolski2 = question.WrongAnswersPolish[1];
            tmp.BlednaOdpPolski3 = question.WrongAnswersPolish[2];

            PytaniaDBContext.SaveChanges();
        }

        private Question QuestionEntityToObject(Pytania entity)
        {
            List<string> tmpListEng = new List<string>();
            List<string> tmpListPol = new List<string>();

            tmpListEng.Add(entity.BlednaOdpAngielski1);
            tmpListEng.Add(entity.BlednaOdpAngielski2);
            tmpListEng.Add(entity.BlednaOdpAngielski3);

            tmpListPol.Add(entity.BlednaOdpPolski1);
            tmpListPol.Add(entity.BlednaOdpPolski2);
            tmpListPol.Add(entity.BlednaOdpPolski3);
            return new Question((int)entity.IdPytania, entity.TrescAngielski, entity.TrescPolski, entity.OdpowiedzAngielski, entity.OdpowiedzPolski, tmpListPol, tmpListEng);
        }

        private Pytania QuestionObjectToEntity(Question question)
        {
            return new Pytania()
            {
                IdPytania = question.GetId(),
                TrescAngielski = question.GetContentEnglish(),
                TrescPolski = question.GetContentPolish(),
                OdpowiedzAngielski = question.GetAnswerEnglish(),
                OdpowiedzPolski = question.GetAnswerPolish(),
                BlednaOdpAngielski1 = question.WrongAnswersEnglish[0],
                BlednaOdpAngielski2 = question.WrongAnswersEnglish[1],
                BlednaOdpAngielski3 = question.WrongAnswersEnglish[2],
                BlednaOdpPolski1 = question.WrongAnswersPolish[0],
                BlednaOdpPolski2 = question.WrongAnswersPolish[1],
                BlednaOdpPolski3 = question.WrongAnswersPolish[2]
            };
        }
    }
}
