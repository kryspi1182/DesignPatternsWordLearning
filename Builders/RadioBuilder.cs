using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ztp_projekt.Builders
{
    class RadioBuilder : IBuilder
    {
        private Grid result = new Grid();

        public void Reset()
        {
            result = new Grid();
        }

        public void BuildHeader()
        {
            RowDefinition header = new RowDefinition();
            header.Height = GridLength.Auto;
            result.RowDefinitions.Add(header);
            Label content = new Label();
            content.Content = "RadioBuilder - header";
            content.Name = "test";
            content.Margin = new Thickness(5);
            content.Padding = new Thickness(5);
            Grid.SetRow(content, 0);
            result.Children.Add(content);
        }

        public void BuildInput(int number)
        {
            RowDefinition input = new RowDefinition();
            input.Height = GridLength.Auto;
            result.RowDefinitions.Add(input);

            StackPanel stackPanel = new StackPanel();
            stackPanel.Margin = new Thickness(5);
            for (int i = 0; i < number; i++)
            {
                stackPanel.Children.Add(new RadioButton());
            }
            Grid.SetRow(stackPanel, 1);
            result.Children.Add(stackPanel);
            
        }

        public Grid GetGrid()
        {
            var tmp = result;
            Reset();
            return tmp;
        }
    }
}
