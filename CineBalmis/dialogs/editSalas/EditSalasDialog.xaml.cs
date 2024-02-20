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

namespace CineBalmis.dialogs.editSalas
{
    /// <summary>
    /// Lógica de interacción para EditSalasDialog.xaml
    /// </summary>
    public partial class EditSalasDialog : Window
    {
        private EditSalasDialogVM vm;
        public EditSalasDialog()
        {
            InitializeComponent();
            vm = new EditSalasDialogVM();
            this.DataContext = vm;
        }
    }
}
