using Controller.BlogNotificationControlers;
using HealthClinic.View.Converter;
using HealthClinic.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace HealthClinic.View
{
    /// <summary>
    /// Interaction logic for Notifications.xaml
    /// </summary>
    public partial class Notifications : Window
    {
        public static RoutedCommand closeSchortcut = new RoutedCommand();

        private readonly NotificationController notificationController;

        public static ObservableCollection<ViewNotification> NotificationView { get; set; }

        public Notifications()
        {
            InitializeComponent();
            this.DataContext = this;
            closeSchortcut.InputGestures.Add(new KeyGesture(Key.Escape));
            CommandBindings.Add(new CommandBinding(closeSchortcut, ShortKey_Click));
            InputSearch.Focus();
            InputSearch.SelectAll();

            var app = Application.Current as App;
            notificationController = app.NotificationController;

            NotificationView = new ObservableCollection<ViewNotification>(NotificationConverter.ConvertNotificationListToNotificationViewList(
                notificationController.GetAllNotificationsForUser(MainWindow.loggedInManager.Id).ToList()));
        }

        private void ShortKey_Click(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
