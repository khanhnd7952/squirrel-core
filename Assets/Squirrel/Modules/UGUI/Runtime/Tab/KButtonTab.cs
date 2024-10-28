using System;
using Squirrel.UGUI.SimpleButton;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Squirrel.UGUI
{
    public class KButtonTab : KButton
    {
        [SerializeField] private GameObject activeButton;

        public void ActiveButton(bool isActive)
        {
            activeButton.SetActive(isActive);
        }

        protected override void OnClick()
        {
            base.OnClick();
            onClick?.Invoke(this);
        }

        public Action<KButtonTab> onClick;
    }
}