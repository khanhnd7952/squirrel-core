// using System;
// using UnityEngine;
//
// namespace ndk.UI.Tween
// {
//     public class GameUITweenManager : MonoBehaviour
//     {
//         [SerializeField] private UITweenManager _show;
//         [SerializeField] private UITweenManager _hide;
//         [SerializeField] private GameObject _panelGroup;
//
//         private void Awake()
//         {
//             throw new NotImplementedException();
//         }
//
//         public void Show(Action onFinish)
//         {
//             _show.Play(onFinish);
//         }
//
//         public void Hide(Action onFinish)
//         {
//             _hide.Play(onFinish);
//         }
//
//         public void ActivePanel(bool active)
//         {
//             _panelGroup.SetActive(active);
//         }
//     }
// }