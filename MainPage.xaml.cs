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

namespace ztp_projekt
{
    /// <summary>
    /// Logika interakcji dla klasy MainPage.xaml
    /// </summary>
    public partial class MainPage : ParentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainPage = this;
        }

        private void testButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Test());
        }

        private void studyButton(object sender, RoutedEventArgs e)
        {
            switch(LanguageSetting)
            {
                case 0:
                    if (StudyPageEnglish == null)
                        StudyPageEnglish = new Study();

                    this.NavigationService.Navigate(StudyPageEnglish);
                    break;

                case 1:
                    if (StudyPagePolish == null)
                        StudyPagePolish = new Study();

                    this.NavigationService.Navigate(StudyPagePolish);
                    break;
            }
            
        }

        private void editButton(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DataEdit());
        }

        private void settingsButton(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.userLanguageSetting = LanguageSetting;
            settings.userUndoSetting = UndoSetting;

            if (LanguageSetting == 1)
                settings.PolishRadioButton.IsChecked = true;
            else
                settings.EnglishRadioButton.IsChecked = true;

            if (UndoSetting == 1)
                settings.AllRadioButton.IsChecked = true;
            else
                settings.SingleRadioButton.IsChecked = true;

            if(settings.ShowDialog()==true)
            {
                LanguageSetting = settings.userLanguageSetting;
                UndoSetting = settings.userUndoSetting;
            }
        }
    }
}
