using System.Windows.Controls;

namespace WpfApp2.Views
{
    public partial class WarehouseView : UserControl
    {
        public WarehouseView()
        {
            InitializeComponent();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (DataContext is ViewModels.WarehouseViewModel vm)
            {
                vm.IsDirty = true;
            }
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (DataContext is ViewModels.WarehouseViewModel vm)
            {
                vm.IsDirty = true;
            }
        }
    }
}