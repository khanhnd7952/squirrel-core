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
            panelGroup = transform.GetChild(0).gameObject;
            tmShow = transform.GetChild(1).GetChild(0).GetComponent<KTweenManager>();
            tmHide = transform.GetChild(1).GetChild(1).GetComponent<KTweenManager>();
            tmShow.InitTween("show");
            tmHide.InitTween("hide");
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

        public void EnablePanel()
        {
            panelGroup.SetActive(true);
        }

        public void DisablePanel()
        {
            panelGroup.SetActive(false);
        }

        public virtual void InternalClickClose()
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