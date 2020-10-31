using HealthClinic.View.ViewModel;
using Model.BlogAndNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.View.Converter
{
    class NotificationConverter : AbstractConverter
    {

        public static ViewNotification ConvertNotificationToNotificationView(Notification notification)
        {
            return new ViewNotification
            {
                Id = notification.GetId(),
                Date = notification.PublishingDate.ToString("dd.MM.yyyy."),
                Sent = notification.SendNotificationByUser.Name + " " + notification.SendNotificationByUser.Surname + ", " +
                notification.SendNotificationByUser.GetType().ToString().Substring(16),
                Title = notification.Title,
            };
        }

        public static IList<ViewNotification> ConvertNotificationListToNotificationViewList(IList<Notification> notifications)
            => ConvertEntityListToViewList(notifications, ConvertNotificationToNotificationView);
    }
}
