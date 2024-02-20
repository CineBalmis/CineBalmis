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

namespace CineBalmis.dialogs.editSesion
{
    /// <summary>
    /// Lógica de interacción para EditSesionDialog.xaml
    /// </summary>
    public partial class EditSesionDialog : Window
    {
        private EditSesionDialogVM vm;
        public EditSesionDialog()
        {
            InitializeComponent();
            vm = new EditSesionDialogVM();
            this.DataContext = vm;
        }
    }
}
