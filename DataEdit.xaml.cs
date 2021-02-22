using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ztp_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy DataEdit.xaml
    /// </summary>
    public partial class DataEdit : ParentPage
    {
        Collection<Question> QuestionList = new ObservableCollection<Question>();
        public DataEdit()
        {
            InitializeComponent();
            QuestionList = QuestionData.GetQuestionsCollection();
            QuestionListBox.ItemsSource = QuestionList;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            ChangeQuestion addQuestion = new ChangeQuestion();
            addQuestion.Title = "Dodanie pytania";
            addQuestion.Action.Content = "Dodaj";
            if (addQuestion.ShowDialog()==true)
            {
                int id = QuestionData.GetNextId();
                List<string> tmpListPol = new List<string>();
                List<string> tmpListEng = new List<string>();

                tmpListEng.Add(addQuestion.newWrongAnswerEnglish1.Text);
                tmpListEng.Add(addQuestion.newWrongAnswerEnglish2.Text);
                tmpListEng.Add(addQuestion.newWrongAnswerEnglish3.Text);

                tmpListPol.Add(addQuestion.newWrongAnswerPolish1.Text);
                tmpListPol.Add(addQuestion.newWrongAnswerPolish2.Text);
                tmpListPol.Add(addQuestion.newWrongAnswerPolish3.Text);

                Question tmp = new Question(
                    ++id,
                    addQuestion.newContentEnglish.Text,
                    addQuestion.newContentPolish.Text,
                    addQuestion.newAnswerEnglish.Text,
                    addQuestion.newAnswerPolish.Text,
                    tmpListPol,
                    tmpListEng);

                QuestionData.AddQuestion(tmp);
                QuestionList.Add(tmp);
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if(QuestionListBox.SelectedIndex >= 0)
            {
                ChangeQuestion editQuestion = new ChangeQuestion();

                editQuestion.Title = "Edycja pytania";

                editQuestion.newContentEnglish.Text = QuestionList[QuestionListBox.SelectedIndex].GetContentEnglish();
                editQuestion.newContentPolish.Text = QuestionList[QuestionListBox.SelectedIndex].GetContentPolish();

                editQuestion.newAnswerEnglish.Text = QuestionList[QuestionListBox.SelectedIndex].GetAnswerEnglish();
                editQuestion.newAnswerPolish.Text = QuestionList[QuestionListBox.SelectedIndex].GetAnswerPolish();

                editQuestion.newWrongAnswerEnglish1.Text = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersEnglish[0];
                editQuestion.newWrongAnswerEnglish2.Text = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersEnglish[1];
                editQuestion.newWrongAnswerEnglish3.Text = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersEnglish[2];

                editQuestion.newWrongAnswerPolish1.Text = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersPolish[0];
                editQuestion.newWrongAnswerPolish2.Text = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersPolish[1];
                editQuestion.newWrongAnswerPolish3.Text = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersPolish[2];

                editQuestion.Action.Content = "Edytuj";

                if (editQuestion.ShowDialog() == true)
                {
                    int id = QuestionList[QuestionListBox.SelectedIndex].GetId();
                    List<string> tmpListPol = new List<string>();
                    List<string> tmpListEng = new List<string>();

                    tmpListEng.Add(editQuestion.newWrongAnswerEnglish1.Text);
                    tmpListEng.Add(editQuestion.newWrongAnswerEnglish2.Text);
                    tmpListEng.Add(editQuestion.newWrongAnswerEnglish3.Text);

                    tmpListPol.Add(editQuestion.newWrongAnswerPolish1.Text);
                    tmpListPol.Add(editQuestion.newWrongAnswerPolish2.Text);
                    tmpListPol.Add(editQuestion.newWrongAnswerPolish3.Text);

                    Question tmp = new Question(
                        id,
                        editQuestion.newContentEnglish.Text,
                        editQuestion.newContentPolish.Text,
                        editQuestion.newAnswerEnglish.Text,
                        editQuestion.newAnswerPolish.Text,
                        tmpListPol,
                        tmpListEng);

                    QuestionData.EditQuestion(tmp);
                    QuestionList[QuestionListBox.SelectedIndex] = tmp;
                }
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if(QuestionListBox.SelectedIndex >= 0)
            {
                MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć to pytanie?", "Uwaga", MessageBoxButton.OKCancel);
                if(result == MessageBoxResult.OK)
                {
                    QuestionData.DeleteQuestion(QuestionList[QuestionListBox.SelectedIndex]);
                    QuestionList.RemoveAt(QuestionListBox.SelectedIndex);
                }
                
            }
        }

        private void updateDetails(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionListBox.SelectedIndex >= 0)
            {
                contentPolish.Text = QuestionList[QuestionListBox.SelectedIndex].GetContentPolish();
                contentEnglish.Text = QuestionList[QuestionListBox.SelectedIndex].GetContentEnglish();
                answerPolish.Text = QuestionList[QuestionListBox.SelectedIndex].GetAnswerPolish();
                answerEnglish.Text = QuestionList[QuestionListBox.SelectedIndex].GetAnswerEnglish();
                wrongAnswersPolish.ItemsSource = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersPolish;
                wrongAnswersEnglish.ItemsSource = QuestionList[QuestionListBox.SelectedIndex].WrongAnswersEnglish;
            }
            else
            {
                contentPolish.Text = "";
                contentEnglish.Text = "";
                answerPolish.Text = "";
                answerEnglish.Text = "";
                wrongAnswersPolish.ItemsSource = null;
                wrongAnswersEnglish.ItemsSource = null;
            }
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(MainPage);
        }
    }
}
