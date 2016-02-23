using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace frmChucNang
{
    /// <summary>
    /// Interaction logic for tmpWin.xaml
    /// </summary>
    public partial class tmpWin : Window
    {
        public tmpWin(UIElement controltoshow)
        {
            InitializeComponent();
            Background.Background = DTO.DefaultConfig.localbg;
            tmpCon.Children.Add(controltoshow);
        }
        public void Out()
        {
            
        }
    }
}
