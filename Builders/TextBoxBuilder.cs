using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace ztp_projekt.Builders
{
    public class TextBoxBuilder : IBuilder
    {
        private Grid result = new Grid();

        public TextBoxBuilder()
        {
            Reset();
        }

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
            content.Content = "TextBoxBuilder - header";
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
            TextBox answer = new TextBox();
            answer.Margin = new Thickness(5);
            answer.Padding = new Thickness(5);
            Grid.SetRow(answer, 1);
            result.Children.Add(answer);
        }

        public Grid GetGrid()
        {
            var tmp = result;
            Reset();
            return tmp;
        }
    }
}
