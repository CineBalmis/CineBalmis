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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CineBalmis.views.salas
{
    /// <summary>
    /// Lógica de interacción para SalasView.xaml
    /// </summary>
    public partial class SalasView : UserControl
    {
        private SalasVM vm;
        public SalasView()
        {
            InitializeComponent();
            vm = new();
            this.DataContext = vm;
        }
    }
}
