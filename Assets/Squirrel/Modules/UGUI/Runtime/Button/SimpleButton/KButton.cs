using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Squirrel.UGUI.SimpleButton
{
    public class KButton : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private float clickDelay = 0.5f;
        [SerializeField] private bool playSound = true;
        [SerializeField] private bool playVibration = true;

        float _lastTimeClick;

        protected virtual void OnClick()
        {
            onClick?.Invoke();
            onClickSuccess?.Invoke();

            // if (playVibration) VibrationController.PlayVibrationClickBtn();
            // if (playSound) SoundController.PlaySoundClick();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (Time.time < _lastTimeClick + clickDelay) return;
            _lastTimeClick = Time.time;
            OnClick();
        }

        public void RegisterOnClick(Action action)
        {
            onClick.AddListener(() => action?.Invoke());
        }

        public void UnRegisterOnClick(Action action)
        {
            onClick.RemoveListener(() => action?.Invoke());
        }


        [SerializeField] UnityEvent onClick = new UnityEvent();
        public static Action onClickSuccess;
    }
}