using System.Collections.ObjectModel;
using WaterCarrierManagementSystem.Desktop.Models;
using WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;

namespace WaterCarrierManagementSystem.Desktop.ViewModels.Implementations;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    public static string Title => "Watercarrier Management System";

    public string SelectedPageName { get; set; } 
    public ObservableCollection<ContractorModel> Contractors 
    {
        get => _contractors;
        set
        {
            _contractors = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<EmployeeModel> Employees
    {
        get => _employees;
        set
        {
            _employees = value;
            OnPropertyChanged();
}
    }
    public ObservableCollection<OrderModel> Orders
    {
        get => _orders;
        set
        {
            _orders = value;
            OnPropertyChanged();
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            _searchText = value;
            OnPropertyChanged();
        }
    }






    private string _searchText = string.Empty;
    private ObservableCollection<ContractorModel> _contractors = [];
    private ObservableCollection<EmployeeModel> _employees = [];
    private ObservableCollection<OrderModel> _orders = [];
}
