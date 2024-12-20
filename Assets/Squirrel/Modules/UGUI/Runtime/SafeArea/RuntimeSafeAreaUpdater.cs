﻿#if KELSEY_ZEGO
using Kelsey;
using UnityEngine;

namespace Squirrel.UGUI
{
    public class RuntimeSafeAreaUpdater : CacheGameComponent<ISafeAreaUpdatable>
    {
        private Rect _safeArea;

        private void Start()
        {
            _safeArea = Screen.safeArea;
            component.UpdateRect();
        }

        protected void Update()
        {
            if (_safeArea == Screen.safeArea) return;
            _safeArea = Screen.safeArea;
            component.UpdateRect();
        }
    }
}
#endif