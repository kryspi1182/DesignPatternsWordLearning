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
using ztp_projekt.Iterators;
using ztp_projekt.Memento;
using ztp_projekt.Bridge;
using ztp_projekt.Command;
using ICommand = ztp_projekt.Command.ICommand;

namespace ztp_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Test.xaml
    /// </summary>
    public partial class Test : ParentPage
    {
        QuestionIterator QuestionIterator;
        MementoCaretaker MementoCaretaker;
        ICommand UndoCommand;
        int index = 0;
        public Test()
        {
            InitializeComponent();
            switch (LanguageSetting)
            {
                case 0:
                    QuestionIterator = new QuestionTestIterator(questions, new English());
                    break;

                case 1:
                    QuestionIterator = new QuestionTestIterator(questions, new Polish());
                    break;
            }

            MementoCaretaker = new MementoCaretaker(QuestionIterator);

            QuestionGrid.Children.Add(QuestionIterator.GetGrid());

            TestProgressBar.Maximum = 44; //4 poziomy trudności po 11 pytań

        }

        private void Submit(object sender, RoutedEventArgs e)
        {
            MementoCaretaker.Backup();
            QuestionIterator.Next();
            QuestionGrid.Children.Clear();
            QuestionGrid.Children.Add(QuestionIterator.GetGrid());
            TestProgressBar.Value = ++index;

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

        private void Undo(object sender, RoutedEventArgs e)
        {
            UndoCommand.Undo();
            QuestionGrid.Children.Clear();
            QuestionGrid.Children.Add(QuestionIterator.GetGrid());
            if (UndoSetting == 0)
                TestProgressBar.Value = --index;
            else
            {
                index = 0;
                TestProgressBar.Value = 0;
            }
        }

        private void Menu(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy chcesz wyjść z testu? Wszystkie odpowiedzi zostaną utracone.", "Uwaga." ,MessageBoxButton.OKCancel);
            if(result == MessageBoxResult.OK)
                this.NavigationService.Navigate(MainPage);
        }
    }
}
