using UnityEngine;

namespace Squirrel
{
    public abstract class SingletonProtected<T> : MonoBehaviour where T : SingletonProtected<T>
    {
        protected static T gInstance { get; private set; }

        protected virtual void Awake()
        {
            if (gInstance == null)
            {
                gInstance = this as T;
            }
            else Destroy(gameObject);
        }
    }
}