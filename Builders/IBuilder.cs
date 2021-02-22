using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ztp_projekt.Builders
{
    public interface IBuilder
    {
        void BuildHeader();

        void BuildInput(int number);

        Grid GetGrid();
    }
}
