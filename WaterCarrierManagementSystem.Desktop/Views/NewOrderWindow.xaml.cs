using System.Windows;

namespace WaterCarrierManagementSystem.Desktop.Views;
public partial class NewOrderWindow : Window
{
    public NewOrderWindow()
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
