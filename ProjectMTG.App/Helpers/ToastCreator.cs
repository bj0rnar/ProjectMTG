using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.UI.ViewManagement;
using Microsoft.Toolkit.Uwp.Notifications;

namespace ProjectMTG.App.Helpers
{
    public static class ToastCreator
    {
        public static void ShowUserToast(string message)
        {
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = message
                        }
                    }
                },
            };

            ToastContent toastContent = new ToastContent()
            {
                Visual = visual
            };

            ToastNotification notification = new ToastNotification(toastContent.GetXml());
            notification.ExpirationTime = DateTime.Now.AddSeconds(2);
            ToastNotificationManager.CreateToastNotifier().Show(notification);
        }
    }
}
