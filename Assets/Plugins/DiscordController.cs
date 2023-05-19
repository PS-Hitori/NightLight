using Discord;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    private static DiscordController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        discord = new Discord.Discord(1105705733435170876, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Timestamps = {
                Start = System.DateTimeOffset.Now.ToUnixTimeMilliseconds()
            },
            Assets =
            {
                LargeImage = "game_logo",
                LargeText = "Night Light"
            }
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord Rich Presence Updated!");
            else
                Debug.LogError("Discord Rich Presence Failed to Update!");
        });
    }

    private void Update()
    {
        discord.RunCallbacks();
        var activityManager = discord.GetActivityManager();
        UnityEditor.EditorApplication.playModeStateChanged += (UnityEditor.PlayModeStateChange state) =>
        {
            if (state == UnityEditor.PlayModeStateChange.ExitingPlayMode || state == UnityEditor.PlayModeStateChange.ExitingEditMode)
            {
                activityManager.ClearActivity((res) =>
                {
                    if (res == Discord.Result.Ok)
                        Debug.Log("Discord Rich Presence Cleared!");
                    else
                        Debug.LogError("Discord Rich Presence Failed to Clear!");
                });
            }
        };
    }
}
