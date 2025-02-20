using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GorillaNotifications
{
    public class NotificationLib : MonoBehaviour
    {
        private class Notification
        {
            public GameObject textObject;
            public TextMeshPro tmp;
            public float notifTime;
            public float creationTime;
            public string text;
        }

        private static List<Notification> activeNotifications = new List<Notification>();

        public static void SendNotification(string Text, bool Important, float NotifTime)
        {
            Notification newNotif = new Notification();
            newNotif.textObject = new GameObject("NotificationText");

            newNotif.tmp = newNotif.textObject.AddComponent<TextMeshPro>();
            newNotif.tmp.font = GorillaTagger.Instance.offlineVRRig.playerText1.font;
            newNotif.tmp.fontSize = 0.35f;
            newNotif.tmp.alignment = TextAlignmentOptions.Center;
            newNotif.tmp.color = Color.white;
            newNotif.tmp.isOverlay = true;

            newNotif.textObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1 - Camera.main.transform.up * .25f;
            newNotif.textObject.transform.SetParent(Camera.main.transform);
            newNotif.textObject.transform.LookAt(Camera.main.transform);
            newNotif.textObject.transform.Rotate(0, 180, 0);
            newNotif.textObject.layer = 19;

            newNotif.notifTime = NotifTime;
            newNotif.creationTime = Time.time;
            newNotif.text = Text;

            if (Important)
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(40, true, 5f);
                newNotif.text = Text;

            }
            else
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(84, true, 5f);
                newNotif.text = Text;
            }

            activeNotifications.Add(newNotif);

            UpdateNotificationText();
            Destroy(newNotif.textObject, NotifTime);
        }

        private static void UpdateNotificationText()
        {
            string allText = "";
            List<Notification> expiredNotifications = new List<Notification>();

            foreach (Notification notif in activeNotifications)
            {
                if (Time.time - notif.creationTime < notif.notifTime)
                {
                    if (allText != "")
                        allText += "\n";
                    allText += notif.text;
                }
                else
                {
                    expiredNotifications.Add(notif);
                }
            }

            foreach (Notification notif in activeNotifications)
            {
                notif.tmp.text = allText;
            }

            foreach (Notification expired in expiredNotifications)
            {
                activeNotifications.Remove(expired);
            }
        }
    }
}