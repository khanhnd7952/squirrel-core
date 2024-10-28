using Cysharp.Threading.Tasks;

namespace Squirrel.UGUI
{
    public class PopupUI<T> : PanelUI where T : PopupUI<T>
    {
        public static T gInstance { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            if (gInstance == null)
            {
                gInstance = this as T;
            }
            else Destroy(this.gameObject);
        }

        public override async UniTask SShow()
        {
            MakePopupToTop();
            await base.SShow();
        }

        void MakePopupToTop()
        {
            transform.SetAsLastSibling();
        }
    }

    public struct EventShowPopup
    {
        public delegate void Delegate(string popupname);

        private static event Delegate OnEvent;

        public static void Register(Delegate callback)
        {
            OnEvent += callback;
        }

        public static void Unregister(Delegate callback)
        {
            OnEvent -= callback;
        }

        public static void Trigger(string popupname)
        {
            OnEvent?.Invoke(popupname);
        }
    }
}