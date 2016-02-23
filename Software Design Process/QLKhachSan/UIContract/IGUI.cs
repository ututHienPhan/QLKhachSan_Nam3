using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UIContract
{
    public abstract class IGUI
    {
        public abstract UserControl GetMainWindow();
    }
}
