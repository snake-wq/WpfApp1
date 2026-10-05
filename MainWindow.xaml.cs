using System.Windows;

namespace WpfVariantApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOpenTaskOne_Click(object sender, RoutedEventArgs e)
        {
            TaskOneWindow taskOneWindow = new TaskOneWindow();
            taskOneWindow.ShowDialog();
        }

        private void BtnOpenTaskTwo_Click(object sender, RoutedEventArgs e)
        {
            TaskTwoWindow taskTwoWindow = new TaskTwoWindow();
            taskTwoWindow.ShowDialog();
        }

        private void BtnOpenTaskThree_Click(object sender, RoutedEventArgs e)
        {
            TaskThreeWindow taskThreeWindow = new TaskThreeWindow();
            taskThreeWindow.ShowDialog();
        }

        private void BtnOpenTaskFour_Click(object sender, RoutedEventArgs e)
        {
            TaskFourWindow taskFourWindow = new TaskFourWindow();
            taskFourWindow.ShowDialog();
        }

        private void BtnOpenTaskFive_Click(object sender, RoutedEventArgs e)
        {
            TaskFiveWindow taskFiveWindow = new TaskFiveWindow();
            taskFiveWindow.ShowDialog();
        }
    }
}