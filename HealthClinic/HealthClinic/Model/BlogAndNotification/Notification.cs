/***********************************************************************
 * Module:  Notification.cs
 * Author:  Hacer
 * Purpose: Definition of the Class Patient.Notification
 ***********************************************************************/

using HealthClinic.Repository;
using Model.AllActors;
using System;
using System.Collections.Generic;

namespace Model.BlogAndNotification
{
    public class Notification : Content, IIdentifiable<int>
    {
        private int id;
        private String title;
        private User sendNotificationByUser;
        private List<User> receiveNotifications;

        public string Title { get => title; set => title = value; }
        public User SendNotificationByUser { get => sendNotificationByUser; set => sendNotificationByUser = value; }
        public List<User> ReceiveNotifications { get => receiveNotifications; set => receiveNotifications = value; }

        public Notification(int id)
        {
            this.id = id;
        }

        public Notification()
        {
        }

        public Notification(int id, string title, User sendNotificationByUser, List<User> receiveNotifications)
        {
            this.Title = title;
            this.id = id;
            this.SendNotificationByUser = sendNotificationByUser;
            this.ReceiveNotifications = receiveNotifications;
        }

        public Notification(string title, User sendNotificationByUser, List<User> receiveNotifications)
        {
            this.Title = title;
            this.SendNotificationByUser = sendNotificationByUser;
            this.ReceiveNotifications = receiveNotifications;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }              

    }
}