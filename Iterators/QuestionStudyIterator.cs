using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ztp_projekt.Builders;
using ztp_projekt.Memento;
using ztp_projekt.Bridge;

namespace ztp_projekt.Iterators
{
    class QuestionStudyIterator : QuestionIterator
    {
        protected double Score; //obecny wynik
        protected int Index; //numer pytania
        protected int Level; //poziom trudnosci
        protected List<Question> Questions = new List<Question>(); //lista pytan
        protected IBuilder Builder;

        protected bool BuilderText = false; //czy obecnie uzywany jest textbox czy radio builder
        protected Grid Grid; //grid zwracany przez iterator
        protected Label Label; //tresc pytania
        protected TextBox TextBox; //input-textbox
        protected StackPanel StackPanel; //input-radio
        protected List<RadioButton> RadioAnswers = new List<RadioButton>();

        protected ILanguage language; //język który użytkownik wybrał


        public QuestionStudyIterator() { }

        public QuestionStudyIterator(List<Question> questions, ILanguage language)
        {
            Score = 0;
            Index = 0;
            Level = 2;

            RadioAnswers.Add(new RadioButton());
            RadioAnswers.Add(new RadioButton());
            RadioAnswers.Add(new RadioButton());
            RadioAnswers.Add(new RadioButton());

            Questions = questions;
            Builder = new RadioBuilder();

            this.language = language;

            BuildGrid();
            WriteQuestionToGrid();
        }
        protected void BuildGrid()
        {
            Builder.BuildHeader();
            Builder.BuildInput(Level);
            Grid = Builder.GetGrid();
            Label = (Label)Grid.Children[0];
            if (BuilderText)
            {
                TextBox = (TextBox)Grid.Children[1];
            }
            else
            {
                StackPanel = (StackPanel)Grid.Children[1];

                for (int i = 0; i < StackPanel.Children.Count; i++)
                {
                    RadioAnswers[i] = (RadioButton)StackPanel.Children[i];
                }
            }
        }
        protected List<string> GetAnswersContent()
        {
            List<string> result = new List<string>();
            foreach (var x in RadioAnswers)
            {
                if (x.Content != null)
                    result.Add(x.Content.ToString());
            }
            return result;
        }
        public IMemento Save()
        {
            if (BuilderText)
            {
                return new IteratorMemento(Label.Content.ToString(), Score, Index, Level, Questions, TextBox.Text); //zapisanie pytania - textbox
            }
            else
            {
                return new IteratorMemento(Label.Content.ToString(), Score, Index, Level, Questions, GetAnswersContent()); //zapisanie pytania - radio
            }
        }
        public void Restore(IMemento memento)
        {
            if (!(memento is IteratorMemento))
            {
                return;
            }
            else
            {
                Score = memento.GetScore();
                Index = memento.GetIndex();
                Level = memento.GetLevel();

                if (memento.IsTextBox()) //przywracanie pytania jesli mialo ono input-textbox
                {

                    if (!BuilderText) //obecne pytanie ma input-radio, trzeba zamienic na textbox
                    {
                        BuilderText = true;
                        Builder = new TextBoxBuilder();
                        BuildGrid();
                    }
                    TextBox.Text = memento.GetTextBox();
                }
                else //przywracanie pytania jesli mialo ono input-radio
                {
                    if (BuilderText) //obecne pytanie ma input-textbox, trzeba zamienic na radio
                    {
                        BuilderText = false;
                        Builder = new RadioBuilder();
                    }
                    BuildGrid();

                    for (int i = 0; i < StackPanel.Children.Count; i++)
                    {
                        RadioAnswers[i].Content = memento.GetAnswers()[i];
                    }
                }
                Label.Content = memento.GetLabel();
            }
        }
        public Grid GetGrid()
        {
            return Grid;
        }
        public double GetScore()
        {
            return Score;
        }
        protected virtual void NextLevelQuestions() //zwiekszenie poziomu trudnosci
        {
            Score = 0;
            ++Level;

            if (Level > 4)
            {
                BuilderText = true;
                Builder = new TextBoxBuilder();
            }
            BuildGrid();
        }
        protected int PickAnswer() //losowa liczba od 0 do ilości pytań zamkniętych
        {
            return new Random().Next(0, Level);
        }
        protected virtual void WriteQuestionToGrid() //zapisanie treści w gridzie
        {
            if (BuilderText)
                Label.Content = language.GetQuestionContent(Questions[Index]);
            else
            {
                Label.Content = language.GetQuestionContent(Questions[Index]);

                int CorrectAnswerIndex = PickAnswer();
                int WrongAnswerIndex = 0;

                for (int i = 0; i < StackPanel.Children.Count; i++)
                {
                    if (i == CorrectAnswerIndex)
                    {
                        RadioAnswers[i].Content = language.GetQuestionAnswer(Questions[Index]);
                    }
                    else
                    {
                        RadioAnswers[i].Content = language.GetWrongAnswers(Questions[Index])[WrongAnswerIndex];
                        WrongAnswerIndex++;
                    }
                    RadioAnswers[i].IsChecked = false;
                }
            }
        }

        protected virtual bool HasNext() //czy nie powinno nastapic przejscie do wyzszego poziomu
        {
            if (Score < 3)
            {
                return true;
            }
            else
                return false;
        }

        public virtual void Next() //iteracja
        {
            CheckAnswer();
            if (HasNext()) //poziom trudnosci taki sam
            {
                if (Index >= Questions.Count - 1) //pula pytan wyczerpana, przejscie do pierwszego pytania
                {
                    Index = 0;
                    WriteQuestionToGrid();
                }
                else //nastepne pytanie
                {
                    Index++;
                    WriteQuestionToGrid();
                }
            }

            else //zwiekszenie poziomu trudnosci
            {
                if (Level < 5) //dostepne wyzsze poziomy trudnosci
                {
                    Index = 0;
                    NextLevelQuestions();
                    WriteQuestionToGrid();
                }

                else //najwyzszy poziom trudnosci
                {
                    if (Index >= Questions.Count - 1) //pula pytan wyczerpana, przejscie do pierwszego pytania
                    {
                        Index = 0;
                        WriteQuestionToGrid();
                    }
                    else //nastepne pytanie
                    {
                        Index++;
                        WriteQuestionToGrid();
                    }
                }
            }
        }

        protected virtual void CheckAnswer() //sprawdzenie odpowiedzi
        {
            if (BuilderText)
            {
                if (language.CheckAnswer(Questions[Index], TextBox.Text))
                    Score++;
                else
                    Score = Score - 0.5;
            }
            else
            {
                foreach (var x in RadioAnswers)
                {
                    if ((bool)x.IsChecked && language.CheckAnswer(Questions[Index], x.Content.ToString()))
                    {
                        Score++;
                        return;
                    }
                }
                Score = Score - 0.5;
            }
        }
    }
}
