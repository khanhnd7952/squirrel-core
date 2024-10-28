using UnityEngine;

namespace Squirrel.Extension
{
    public class CanvasBounder : MonoBehaviour
    {
        private Canvas _canvas;

        Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = GetComponentInParent<Canvas>();
                }

                return _canvas;
            }
        }

        public Bounds GetBounds()
        {
            if(Canvas == null) return new Bounds();
            return new Bounds(GetPosition(), GetSize());
        }

        public Vector2 GetSize()
        {
            if(Canvas == null) return Vector2.zero;
            return (transform as RectTransform).CanvasObjectToWorldSize(Canvas);
        }

        public Vector3 GetPosition()
        {
            if(Canvas == null) return Vector3.zero;
            var position = transform.CanvasObjectToWorldPosition(Canvas);
            position.z = 0f;
            return position;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var bound = GetBounds();
            Gizmos.DrawWireCube(bound.center, bound.size);
        }
    }
}