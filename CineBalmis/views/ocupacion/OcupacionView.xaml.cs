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

namespace CineBalmis.views.ocupacion
{
    /// <summary>
    /// Lógica de interacción para OcupacionView.xaml
    /// </summary>
    public partial class OcupacionView : UserControl
    {
        private OcupacionVM vm;
        public OcupacionView()
        {
            InitializeComponent();
            vm = new();
            this.DataContext = vm;
        }
    }
}
