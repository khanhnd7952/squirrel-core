//using Kelsey.Audio;

using UnityEngine;
using UnityEngine.EventSystems;

namespace Squirrel.UGUI
{
    public class UIButtonClickSound : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            //if (SoundController.gInstance != null) SoundController.gInstance.PlayClickButton();
        }
    }
}