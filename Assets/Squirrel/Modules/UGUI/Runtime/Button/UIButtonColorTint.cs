using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Squirrel.UGUI
{
    [RequireComponent(typeof(Image))]
    public class UIButtonColorTint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Image _image;
        float minScale = 0.85f;
        float scaleDuration = 0.15f;

        private Color originColor;
        private Color targetColor;
        private bool isScaling = false;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            originColor = _image.color;
            targetColor = new Color(originColor.r * 0.8f, originColor.g * 0.8f, originColor.b * 0.8f);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isScaling = true;

            _image.DOColor(targetColor, scaleDuration);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isScaling)
            {
                isScaling = false;
                _image.DOColor(originColor, scaleDuration);
            }
        }
    }
}