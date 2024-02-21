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
    /// Lógica de interacción para Ocupacion.xaml
    /// </summary>
    public partial class Ocupacion : UserControl
    {
        private OcupacionVM vm;
        public Ocupacion()
        {
            InitializeComponent();
            vm = new OcupacionVM();
            this.DataContext = vm;
        }
    }
}
