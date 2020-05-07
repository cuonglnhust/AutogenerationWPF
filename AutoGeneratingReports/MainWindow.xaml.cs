﻿using AutoGeneratingReports.Service;
using AutoGeneratingReports.ViewModel;
using AutoGenReport.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

namespace AutoGeneratingReports
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AutoGenReportDbContext _DbContext = new AutoGenReportDbContext();
        public MainWindow(AutoGenReportDbContext dbContext )
        {
            _DbContext = dbContext;
            MainWindowViewModel VM = new MainWindowViewModel(_DbContext);
            this.DataContext = VM;
            if (VM.CloseAction == null)
            {
                VM.CloseAction = new Action(() => this.Close());
            }
            VM.DataGridAm = GridDataAM;
          
            InitializeComponent();
        }

        private void RibbonWin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MainWindowViewModel VM = new MainWindowViewModel(_DbContext);
            var indexer = RibbonWin.SelectedIndex;
            //VM.IndexTab = RibbonWin == null ? -1 : RibbonWin.SelectedIndex;
            if (indexer == 0)
            {
                GridAeonMall.Visibility = Visibility.Visible;
                GridAeonVN.Visibility = Visibility.Hidden;
            }
            if(indexer == 1)
            {
                GridAeonMall.Visibility = Visibility.Hidden;
                GridAeonVN.Visibility = Visibility.Visible;
            }
            if(indexer == 2)
            {
                GridAeonMall.Visibility = Visibility.Hidden;
                GridAeonVN.Visibility = Visibility.Hidden;
            }
            if (indexer == 3)
            {
                GridAeonMall.Visibility = Visibility.Hidden;
                GridAeonVN.Visibility = Visibility.Hidden;
            }
            if (indexer == 4)
            {
                GridAeonMall.Visibility = Visibility.Hidden;
                GridAeonVN.Visibility = Visibility.Hidden;
            }
        }

        private void SelectionAM(object sender, SelectionChangedEventArgs e)
        {
            object item = GridDataAM.SelectedItem;
           
            //string ID = (GridDataAM.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            //MessageBox.Show(ID);
            var row_list = GetDataGridRows(GridDataAM);
            foreach (object color in e.AddedItems)
            {
                
            }
            foreach (DataGridRow single_row in row_list)
            {
                if (single_row.IsSelected == true)
                {

                    //bool check = (GridDataAM.SelectedCells[13].Column.GetCellContent(item) as CheckBox).IsChecked.Value;
                    ////GridDataAM.Columns[13].Visibility = Visibility.Hidden;
                    ////MessageBox.Show(check.ToString());
                    ////MessageBox.Show("the row no." + single_row.GetIndex().ToString() + " is selected!");
                    //MainService mainService = new MainService(_DbContext);
                    //mainService.UpdateCheckbox("20160701154710410012411000000000200101", check.ToString());
                    //MessageBox.Show(single_row.GetIndex().ToString());
                }
            }
        }
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
      
        private void GridDataAM_CurrentCellChanged(object sender, EventArgs e)
        {
            var curentCell = GridDataAM.CurrentCell;
            var row = (DataRowView)curentCell.Item;

            if(row!=null)
            {
                var ID= row.Row["ID Lịch sử gửi tiền"].ToString();
                //var row2 = row.Item as DataRow;
                var CheckedRow = (bool)row.Row["Đã kiểm tra"];
                MainService mainService = new MainService(_DbContext);
                mainService.UpdateCheckbox(ID, CheckedRow.ToString());

            }    
        }       
        private void GridDataAM_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //var curentCell = GridDataAM.CurrentCell;
            //var row = curentCell.Item as DataRowView;

            //if (row != null)
            //{
            //    var x = row.Row["Thiết bị"];
            //    //var row2 = row.Item as DataRow;
            //    var y = (bool)row.Row["Đã kiểm tra"];
            //}
        }

        private void DataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            var curentCell = GridDataAV.CurrentCell;
            var row = (DataRowView)curentCell.Item;

            if (row != null)
            {
                var ID = row.Row["ID Lịch sử gửi tiền"].ToString();
                //var row2 = row.Item as DataRow;
                var CheckedRow = (bool)row.Row["Đã kiểm tra"];
                MainService mainService = new MainService(_DbContext);
                mainService.UpdateCheckbox(ID, CheckedRow.ToString());

            }
        }

        private void RibbonButton_Click(object sender, RoutedEventArgs e)
        {
            GridDataAM.Columns[1].Visibility = Visibility.Hidden;
            GridDataAV.Columns[1].Visibility = Visibility.Hidden;
            GridDataAM.Columns[2].Visibility = Visibility.Hidden;
            GridDataAV.Columns[2].Visibility = Visibility.Hidden;
        }

        private void RibbonButton_Click_1(object sender, RoutedEventArgs e)
        {
            GridDataAM.Columns[1].Visibility = Visibility.Hidden;
            GridDataAV.Columns[1].Visibility = Visibility.Hidden;
            GridDataAM.Columns[2].Visibility = Visibility.Hidden;
            GridDataAV.Columns[2].Visibility = Visibility.Hidden;
        }

        
    }
}
