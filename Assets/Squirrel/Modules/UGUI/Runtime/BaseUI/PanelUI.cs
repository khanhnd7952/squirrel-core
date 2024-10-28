using System;
using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Squirrel.UGUI
{
    public class PanelUI : MonoBehaviour
    {
        [ReadOnly] [SerializeField] protected GameObject panelGroup;
        [ReadOnly] [SerializeField] protected KTweenManager tmShow, tmHide;
        [ReadOnly] [ShowInInspector] public bool IsShow { get; private set; } = false;

        const string SHOW_TWEEN_ID = "show";
        const string HIDE_TWEEN_ID = "hide";

        bool clickPermission = true;

        protected virtual void OnValidate()
        {
        }

        protected virtual void Awake()
        {
            InitTween();
            DisablePanel();
        }

        [Button]
        protected void InitTween()
        {
            panelGroup = transform.GetChild(0).GetChild(0).gameObject;
            tmShow = new KTweenManager();
            tmHide = new KTweenManager();
            tmShow.InitTween(transform.GetChild(0).gameObject, SHOW_TWEEN_ID);
            tmHide.InitTween(transform.GetChild(0).gameObject, HIDE_TWEEN_ID);
        }

        [Button]
        public virtual async UniTask SShow()
        {
            if (IsShow) return;
            EnablePanel();
            IsShow = true;
            tmHide.StopAllTween();

            InvokeOnShowStart();
            await tmShow.Play();
            InvokeOnShowDone();
        }

        [Button]
        public virtual async UniTask HHide()
        {
            if (!IsShow) return;
            IsShow = false;
            tmShow.StopAllTween();

            InvokeOnHideStart();
            await tmHide.Play();
            InvokeOnHideDone();
            DisablePanel();
        }

        public void RegisterOnHideStart(Action onClose)
        {
            onHide += onClose;
        }

        public void RegisterOnHideDone(Action onClose)
        {
            onHideDone += onClose;
        }

        public void RegisterOnShowStart(Action onClose)
        {
            onShow += onClose;
        }

        public void RegisterOnShowDone(Action onClose)
        {
            onShowDone += onClose;
        }

        void InvokeOnShowDone()
        {
            onShowDone?.Invoke();
            onShowDone = null;
        }

        void InvokeOnHideDone()
        {
            onHideDone?.Invoke();
            onHideDone = null;
        }

        void InvokeOnShowStart()
        {
            onShow?.Invoke();
            onShow = null;
        }

        void InvokeOnHideStart()
        {
            onHide?.Invoke();
            onHide = null;
        }

        void EnablePanel()
        {
            panelGroup.SetActive(true);
        }

        void DisablePanel()
        {
            panelGroup.SetActive(false);
        }

        public void InternalClickClose()
        {
            HHide();
        }

        public Action onShowDoneFixedTransition;
        public Action onShow;
        public Action onShowDone;
        public Action onHideDoneFixedTransision;
        public Action onHide;
        public Action onHideDone;
    }
}