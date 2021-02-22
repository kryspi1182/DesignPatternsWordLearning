using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ztp_projekt.Memento;

namespace ztp_projekt.Command
{
    class UndoAll : ICommand
    {
        private MementoCaretaker mementoCaretaker;

        public UndoAll(MementoCaretaker mementoCaretaker)
        {
            this.mementoCaretaker = mementoCaretaker;
        }

        public void Undo()
        {
            mementoCaretaker.UndoAll();
        }
    }
}
