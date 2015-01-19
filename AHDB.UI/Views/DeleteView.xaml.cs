using AHDB.UI.Common;
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
    /// Interaction logic for DeleteView.xaml
    /// </summary>
    public partial class DeleteView : Window
    {
        public DeleteView(IViewModel entity)
        {
            InitializeComponent();
            var vm = new DeleteViewModel(entity);

            this.DataContext = vm;

            if (vm.RefreshAction == null)
            {
                vm.RefreshAction = new Action(() => MainWindowViewModel.Instance.RefreshRepairs());
            }
            if (vm.CloseAction == null)
            {
                vm.CloseAction = new Action(() => this.Close());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
