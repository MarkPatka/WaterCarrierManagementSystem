using System.Windows.Input;

namespace WaterCarrierManagementSystem.Desktop.Commands.Abstract;

public interface ICommandFactory
{
    public T GetCommand<T>() where T : notnull, ICommand;
   
}
