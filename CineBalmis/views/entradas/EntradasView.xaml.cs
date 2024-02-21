using CineBalmis.views.Entradas;
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

namespace CineBalmis.views.entradas
{
    /// <summary>
    /// Lógica de interacción para EntradasView.xaml
    /// </summary>
    public partial class EntradasView : UserControl
    {
        private readonly EntradasVM vm;
        public EntradasView()
        {
            InitializeComponent();
            vm = new();
            DataContext = vm;
        }
    }
}
