using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ztp_projekt.Memento
{
    public interface IMemento
    {
        string GetLabel();
        double GetScore();
        int GetIndex();
        int GetLevel();
        List<string> GetAnswers();
        string GetTextBox();
        bool IsTextBox();

    }
}
