using UnityEngine;

namespace Squirrel
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        [SerializeField] bool DontDestroyOnLoad = false;

        public static T gInstance { get; private set; }

        protected virtual void Awake()
        {
            if (gInstance == null)
            {
                gInstance = this as T;
                Init();
                if (DontDestroyOnLoad) DontDestroyOnLoad(this.gameObject);
            }
            else Destroy(this.gameObject);
        }

        protected virtual void Init()
        {
        }
    }
}