using UnityEngine;

namespace Squirrel
{
    public abstract class SingletonProtected<T> : MonoBehaviour where T : SingletonProtected<T>
    {
        protected static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this as T;
            }
            else Destroy(gameObject);
        }
    }
}