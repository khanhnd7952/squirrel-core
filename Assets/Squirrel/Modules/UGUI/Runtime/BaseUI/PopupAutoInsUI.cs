using Cysharp.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Squirrel.UGUI
{
    public class PopupAutoInsUI<T> : PanelUI where T : PopupAutoInsUI<T>
    {
        private static T _instance;

        public static T gInstance
        {
            get
            {
                if (_instance == null)
                {
                    var popup = Resources.Load<T>($"UI/Popups/{typeof(T).Name}");
                    if (popup == null) popup = Resources.Load<T>($"UIPopup/{typeof(T).Name}");
                    var popopManager = CanvasPopupContainer.gInstance;
                    _instance = Instantiate(popup as T, popopManager.transform);
                    _instance.InitTween();
                }

                return _instance;
            }
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


#if UNITY_EDITOR
        protected override void OnValidate()
        {
            Rename();
        }

        [Button]
        void Rename()
        {
            if (name != typeof(T).Name)
            {
                name = typeof(T).Name;
                EditorUtility.SetDirty(this);
            }
        }
#endif
    }
}