using System;
using UnityEngine;

namespace Squirrel.UGUI
{
    public class PushEventOnEnable : MonoBehaviour
    {
        private void OnEnable()
        {
            onEnable?.Invoke();
        }

        public Action onEnable;
    }
}