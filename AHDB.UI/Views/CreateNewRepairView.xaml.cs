using AHDB.UI.ViewModels;
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

namespace AHDB.UI.Views
{
    /// <summary>
    /// Interaction logic for CreateNewRepairView.xaml
    /// </summary>
    public partial class CreateNewRepairView : Window
    {
        public CreateNewRepairView()
        {
            InitializeComponent();
            var vm = new CreateNewRepairViewModel();

            this.DataContext = vm;
            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(() => this.Close());
            }
            if (vm.Refresh == null)
            {
                vm.Refresh = new Action(() => MainWindowViewModel.Instance.Refresh());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
