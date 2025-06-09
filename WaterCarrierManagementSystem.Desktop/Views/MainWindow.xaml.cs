using System.Windows;

namespace WaterCarrierManagementSystem.Desktop.Views;

public partial class MainWindow : Window
{
    private bool _isMaximized;

    public MainWindow()
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

    private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (_isMaximized)
            {
                WindowState = WindowState.Normal;
                this.Width = 1080;
                this.Height = 720;

                _isMaximized = false;
            }
            else
            {
                WindowState = WindowState.Maximized;
                _isMaximized = true;
            }
        }

    }
}