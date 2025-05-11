using UnityEngine;

#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine.Android;
#endif

public class NotificationSystem : SingletonPersistent<NotificationSystem>
{
    [Header("Events")]
    [SerializeField] GameEvent onNotificationPermissionGranted;
    [SerializeField] GameEvent onNotificationPermissionDenied;
    [SerializeField] GameEventString onNotificationSent;

    private const string CHANNEL_ID = "default_channel";

    public override void Awake()
    {
        base.Awake();
        Initialize();
    }

    private void Initialize()
    {
#if UNITY_ANDROID
        RequestAuthorization();
        CreateNotificationChannel();
#endif
    }

#if UNITY_ANDROID
    private void RequestAuthorization()
    {
        if (Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS")) 
            return;

        var callbacks = new PermissionCallbacks();
        callbacks.PermissionGranted += _ => onNotificationPermissionGranted?.Raise();
        callbacks.PermissionDenied += _ => onNotificationPermissionDenied?.Raise();
        
        Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS", callbacks);
    }

    private void CreateNotificationChannel()
    {
        var channel = new AndroidNotificationChannel
        {
            Id = CHANNEL_ID,
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void ScheduleNotification(string title, string text, int hoursUntilTrigger)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = text,
            FireTime = DateTime.Now.AddHours(hoursUntilTrigger),
            SmallIcon = "icon_small",
            LargeIcon = "icon_large"
        };

        AndroidNotificationCenter.SendNotification(notification, CHANNEL_ID);
        onNotificationSent?.Raise($"{title}|{text}"); // Formato personalizable
    }
#endif
}