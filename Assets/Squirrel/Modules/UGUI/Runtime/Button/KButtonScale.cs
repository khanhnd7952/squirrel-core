using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Squirrel.UGUI
{
    //[ExecuteInEditMode]
    public class KButtonScale : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] float minScale = 0.9f;
        float scaleDuration = 0.15f;

        private Vector3 originalScale = Vector3.one;
        private bool isScaling = false;

        private void Start()
        {
            originalScale = transform.localScale;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isScaling = true;
            transform.DOKill();
            transform.DOScale(new Vector3(minScale * originalScale.x, minScale * originalScale.y, 1f), scaleDuration);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (isScaling)
            {
                isScaling = false;
                transform.DOKill();
                transform.DOScale(originalScale, scaleDuration);
            }
        }
    }
}