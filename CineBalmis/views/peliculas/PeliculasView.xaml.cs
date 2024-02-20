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

namespace CineBalmis.views.peliculas
{
    /// <summary>
    /// Lógica de interacción para PeliculasView.xaml
    /// </summary>
    public partial class PeliculasView : UserControl
    {
        private PeliculasVM vm;
        public PeliculasView()
        {
            InitializeComponent();
            vm = new PeliculasVM();
            this.DataContext = vm;
        }
    }
}
