#if KELSEY_SOAP
using Obvious.Soap;
using UnityEngine;

namespace Squirrel.ScriptableExtension
{
    [CreateAssetMenu(fileName = "scriptable_event_vector2-float.asset", menuName = "Soap/ScriptableEvents/vector2-float")]
    public class ScriptableEventVector2Float : ScriptableEvent<(Vector2, float)>
    {
    }
}
#endif