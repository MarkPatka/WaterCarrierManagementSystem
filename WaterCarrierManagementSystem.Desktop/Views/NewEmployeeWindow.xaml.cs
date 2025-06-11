using System.Windows;

namespace WaterCarrierManagementSystem.Desktop.Views;
public partial class NewEmployeeWindow : Window
{
    public NewEmployeeWindow()
    {
        InitializeComponent();
    }

    private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (e.LeftButton is System.Windows.Input.MouseButtonState.Pressed)
        {
            DragMove();
        }
    }

}
