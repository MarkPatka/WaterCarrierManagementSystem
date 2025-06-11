namespace WaterCarrierManagementSystem.Desktop.ViewModels.Interfaces;

public interface IViewModelFactory
{
    public T GetViewModel<T>() where T : notnull, IBaseViewModel;

}
