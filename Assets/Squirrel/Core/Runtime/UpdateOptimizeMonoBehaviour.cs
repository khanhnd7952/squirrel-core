using UnityEngine;

namespace Squirrel
{
    public abstract class UpdateOptimizeMonoBehaviour : MonoBehaviour
    {
        private float _lastTimeUpdate;

        protected virtual void Update()
        {
            if (Time.unscaledTime > _lastTimeUpdate + GetTimeInterval())
            {
                _lastTimeUpdate = Time.unscaledTime;
                DoUpdate();
            }
        }

        protected virtual void OnEnable()
        {
            DoUpdate();
        }

        protected abstract void DoUpdate();

        protected virtual float GetTimeInterval() => 1f;
    }
}