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

namespace CineBalmis.dialogs.addVentas
{
    /// <summary>
    /// Lógica de interacción para AddVentasDialog.xaml
    /// </summary>
    public partial class AddVentasDialog : Window
    {
        private AddVentasDialogVM vm;
        public AddVentasDialog()
        {
            InitializeComponent();
            vm = new AddVentasDialogVM();
            this.DataContext = vm;
        }
    }
}
