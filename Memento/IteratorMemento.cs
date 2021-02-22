using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ztp_projekt.Memento
{
    class IteratorMemento : IMemento
    {
        private string label;
        private double score;
        private int index;
        private int level;
        private List<string> answers;
        private string textbox;
        private bool builderText;
        public IteratorMemento(string label, double score, int index, int level, List<Question> questions, string textbox)
        {
            this.label = label;
            this.score = score;
            this.index = index;
            this.level = level;
            this.textbox = textbox;
            builderText = true;
        }
        public IteratorMemento(string label, double score, int index, int level, List<Question> questions, List<string> answers)
        {
            this.label = label;
            this.score = score;
            this.index = index;
            this.level = level;
            this.answers = answers;
            builderText = false;
        }

        public string GetLabel()
        {
            return this.label;
        }

        public double GetScore()
        {
            return this.score;
        }

        public int GetIndex()
        {
            return this.index;
        }

        public int GetLevel()
        {
            return this.level;
        }

        public List<string> GetAnswers()
        {
            return this.answers;
        }

        public string GetTextBox()
        {
            return this.textbox;
        }

        public bool IsTextBox()
        {
            return this.builderText;
        }
    }
}
