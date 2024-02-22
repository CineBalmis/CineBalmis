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

namespace CineBalmis.dialogs.addSesion
{
    /// <summary>
    /// Lógica de interacción para AddSesionDialog.xaml
    /// </summary>
    public partial class AddSesionDialog : Window
    {
        private AddSesionDialogVM vm;
        public AddSesionDialog()
        {
            InitializeComponent();
            vm = new AddSesionDialogVM();
            this.DataContext = vm;
        }
    }
}
