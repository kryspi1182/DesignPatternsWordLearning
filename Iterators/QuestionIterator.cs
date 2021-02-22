using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ztp_projekt.Memento;

namespace ztp_projekt.Iterators
{
    public interface QuestionIterator
    { 
        Grid GetGrid();
        void Restore(IMemento memento);
        IMemento Save();
        double GetScore();
        void Next();

    }
}
