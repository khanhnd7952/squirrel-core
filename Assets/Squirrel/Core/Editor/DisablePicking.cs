using UnityEditor;
using UnityEngine;

namespace Kelsey
{
    [ExecuteInEditMode]
    public class DisablePicking : MonoBehaviour
    {
#if UNITY_EDITOR
        private void Update()
        {
            if (SceneVisibilityManager.instance.IsPickingDisabled(gameObject)) return;
            SceneVisibilityManager.instance.DisablePicking(gameObject, true);
        }
#endif
    }
}