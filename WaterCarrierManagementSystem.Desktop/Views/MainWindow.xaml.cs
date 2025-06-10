using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

    public string ActiveTabName
    {
        get { return (string)GetValue(ActiveTabNameProperty); }
        set { SetValue(ActiveTabNameProperty, value); }
    }

    public static readonly DependencyProperty ActiveTabNameProperty =
        DependencyProperty.Register("ActiveTabName", typeof(string), typeof(MainWindow), new PropertyMetadata(string.Empty));

    private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (sender is TabControl tabControl)
        {
            if (tabControl.SelectedItem is TabItem selectedTab)
            {
                ActiveTabName = selectedTab.Header.ToString() ?? "";
            }
        }
    }
}