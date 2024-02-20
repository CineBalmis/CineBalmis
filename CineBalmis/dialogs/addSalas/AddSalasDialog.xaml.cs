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

namespace CineBalmis.dialogs.addSalas
{
    /// <summary>
    /// Lógica de interacción para AddSalasDialog.xaml
    /// </summary>
    public partial class AddSalasDialog : Window
    {
        private AddSalasDialogVM vm;
        public AddSalasDialog()
        {
            InitializeComponent();
            vm = new AddSalasDialogVM();
            this.DataContext = vm;
        }
    }
}
