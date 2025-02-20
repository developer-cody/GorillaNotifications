# GorillaNotifications!

**GorillaNotifications** is a mod for Gorilla Tag that allows you to send in-game notifications displayed as text overlays in front of the player’s camera. These notifications can be customized with different durations and importance levels, with important notifications triggering a hand tap sound effect. It’s a great tool for developers or anyone wanting to provide reminders or alerts to players during gameplay.

### Features:
- Display text notifications as an overlay in front of the player's camera.
- Set the duration of the notification.
- Option to mark notifications as important, which triggers a sound effect.
- Notifications automatically disappear after the specified time.

### Installation:
1. Install [BepInEx](https://github.com/BepInEx/BepInEx) framework.
2. Download the latest version of **GorillaNotifications** mod.
3. Place the mod `.dll` file into your BepInEx `plugins` folder.
4. Launch **Gorilla Tag**, and the notification system will be ready to use.

### Usage:
- To send a notification, call the `NotificationLib.SendNotification()` method with the desired text, whether it’s important, and the duration in seconds.
  - Example:
    ```csharp
    NotificationLib.SendNotification("Important Update!", true, 5f); // 5 seconds
    ```

### Compatibility:
This mod requires the **BepInEx** framework and is compatible with the latest version of **Gorilla Tag**.
