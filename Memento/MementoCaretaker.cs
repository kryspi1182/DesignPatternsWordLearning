using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ztp_projekt.Iterators;

namespace ztp_projekt.Memento
{
    class MementoCaretaker
    {
        private List<IMemento> mementos = new List<IMemento>();

        private QuestionIterator iterator = null;

        public MementoCaretaker(QuestionIterator questionIterator)
        {
            this.iterator = questionIterator;
        }

        public void Backup()
        {
            this.mementos.Add(this.iterator.Save());
        }

        public void Undo()
        {
            if (this.mementos.Count == 0)
            {
                return;
            }

            var memento = this.mementos.Last();
            this.mementos.Remove(memento);

            try
            {
                this.iterator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }
        public void UndoAll()
        {
            if (this.mementos.Count == 0)
            {
                return;
            }

            var memento = this.mementos.First();
            this.mementos.Clear();

            try
            {
                this.iterator.Restore(memento);
            }
            catch (Exception)
            {

            }
        }
    }
}
