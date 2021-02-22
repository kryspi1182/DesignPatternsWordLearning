using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ztp_projekt.Memento;

namespace ztp_projekt.Command
{
    class UndoSingle : ICommand
    {
        private MementoCaretaker mementoCaretaker;

        public UndoSingle(MementoCaretaker mementoCaretaker)
        {
            this.mementoCaretaker = mementoCaretaker;
        }

        public void Undo()
        {
            mementoCaretaker.Undo();
        }
    }
}
