using BepInEx;
using UnityEngine;

namespace GorillaNotifications
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class GorillaNotificationsPlugin : BaseUnityPlugin
    {
        public const string MyGUID = "com.SillyCody.GorillaNotifications";
        public const string PluginName = "GorillaNotifications";
        public const string VersionString = "2.0.0";

        private void Start()
        {
            var gorillaNotif = new GameObject("GorillaNotif");
            DontDestroyOnLoad(gorillaNotif);
            gorillaNotif.AddComponent<NotificationLib>();
        }
    }
}