using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ztp_projekt.Bridge;
using ztp_projekt.Builders;

namespace ztp_projekt.Iterators
{
    class QuestionTestIterator : QuestionStudyIterator
    {
        public QuestionTestIterator(List<Question> questions, ILanguage language) : base(questions, language)
        {

        }

        protected override void NextLevelQuestions() //zwiekszenie poziomu trudnosci
        {
            ++Level;

            if (Level > 4)
            {
                BuilderText = true;
                Builder = new TextBoxBuilder();
            }
            BuildGrid();
        }
        protected override void WriteQuestionToGrid() //zapisanie treści w gridzie
        {
            if (BuilderText)
                Label.Content = language.GetQuestionContent(Questions[Index % Questions.Count]);
            else
            {
                Label.Content = language.GetQuestionContent(Questions[Index % Questions.Count]);

                int CorrectAnswerIndex = PickAnswer();
                int WrongAnswerIndex = 0;

                for (int i = 0; i < StackPanel.Children.Count; i++)
                {
                    if (i == CorrectAnswerIndex)
                    {
                        RadioAnswers[i].Content = language.GetQuestionAnswer(Questions[Index % Questions.Count]);
                    }
                    else
                    {
                        RadioAnswers[i].Content = language.GetWrongAnswers(Questions[Index % Questions.Count])[WrongAnswerIndex];
                        WrongAnswerIndex++;
                    }
                    RadioAnswers[i].IsChecked = false;
                }
            }
        }
        protected override bool HasNext()
        {
            if (Index < 10)
            {
                return true;
            }
            else
                return false;
        }

        public override void Next() //iteracja
        {
            CheckAnswer();
            if (HasNext()) //poziom trudnosci taki sam
            {
                Index++;
                WriteQuestionToGrid();
            }

            else //zwiekszenie poziomu trudnosci
            {
                if (Level < 5) //dostepne wyzsze poziomy trudnosci
                {
                    Index = 0;
                    NextLevelQuestions();
                    WriteQuestionToGrid();
                }

                else //koniec
                {
                    Label.Content = "Koniec testu! Twój wynik to: " + Score + " pkt!";   
                }
            }
        }

        protected override void CheckAnswer() //sprawdzenie odpowiedzi
        {
            if (BuilderText)
            {
                if (language.CheckAnswer(Questions[Index % Questions.Count], TextBox.Text))
                    Score++;
            }
            else
            {
                foreach (var x in RadioAnswers)
                {
                    if ((bool)x.IsChecked && language.CheckAnswer(Questions[Index % Questions.Count], x.Content.ToString()))
                    {
                        Score++;
                        return;
                    }
                }
            }
        }
    }
}
