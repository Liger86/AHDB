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
using AHDB.UI.ViewModels;

namespace AHDB.UI.Views
{
    /// <summary>
    /// Interaction logic for CreateNewCustomerView.xaml
    /// </summary>
    public partial class CreateNewCustomerView : Window
    {
        public CreateNewCustomerView()
        {
            InitializeComponent();
            var vm = new CreateNewCustomerViewModel();

            this.DataContext = vm;
            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(() => this.Close());
            }
            if (vm.RefreshAction == null)
            {
                vm.RefreshAction = new Action(() => MainWindowViewModel.Instance.Refresh());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
