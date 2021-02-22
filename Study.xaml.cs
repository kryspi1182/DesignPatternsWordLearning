using System;
using System.Collections.Generic;
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
using ztp_projekt.Builders;
using ztp_projekt.Iterators;
using ztp_projekt.Memento;
using ztp_projekt.Bridge;
using ztp_projekt.Command;
using ICommand = ztp_projekt.Command.ICommand;

namespace ztp_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Study.xaml
    /// </summary>
    public partial class Study : ParentPage
    {

        QuestionIterator QuestionIterator;
        MementoCaretaker MementoCaretaker;
        ICommand UndoCommand;
        public Study()
        {
            InitializeComponent();
            switch(LanguageSetting)
            {
                case 0:
                    QuestionIterator = new QuestionStudyIterator(questions, new English());
                    StudyPageEnglish = this;
                    break;

                case 1:
                    QuestionIterator = new QuestionStudyIterator(questions, new Polish());
                    StudyPagePolish = this;
                    break;
            }
            
            MementoCaretaker = new MementoCaretaker(QuestionIterator);

            

            QuestionGrid.Children.Add(QuestionIterator.GetGrid());

        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            MementoCaretaker.Backup();
            QuestionIterator.Next();
            QuestionGrid.Children.Clear();
            QuestionGrid.Children.Add(QuestionIterator.GetGrid());

            Score.Text = QuestionIterator.GetScore().ToString() + " pkt.";
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (UndoSetting)
            {
                case 0:
                    UndoCommand = new UndoSingle(MementoCaretaker);
                    break;

                case 1:
                    UndoCommand = new UndoAll(MementoCaretaker);
                    break;
            }
        }


        private void Undo()
        {
            UndoCommand.Undo();
            QuestionGrid.Children.Clear();
            QuestionGrid.Children.Add(QuestionIterator.GetGrid());

            Score.Text = QuestionIterator.GetScore().ToString() + " pkt.";
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            Undo();
        }

        private void Undo(object sender, ExecutedRoutedEventArgs e)
        {
            Undo();
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(MainPage);
        }
    }
}
