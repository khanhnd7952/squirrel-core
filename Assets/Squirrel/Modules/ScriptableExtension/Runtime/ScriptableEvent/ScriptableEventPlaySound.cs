using Kelsey.Scriptable;
using UnityEngine;

namespace Squirrel.ScriptableExtension
{
    /// <summary>
    /// clip, volume, pitch, time
    /// </summary>
    [CreateAssetMenu(fileName = "scriptable_event_play-sound.asset", menuName = "Soap/ScriptableEvents/play-sound")]
    public class ScriptableEventPlaySound : ScriptableEvent<(AudioClip, float, float, float)>
    {
        public void Play(AudioClip clip, float volume = 1, float pitch = 1, float delay = 0)
        {
            Raise((clip, volume, pitch, delay));
        }
    }
}