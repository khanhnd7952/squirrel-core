using System.Collections.Generic;
using UnityEngine;

namespace Squirrel
{
    public abstract class SingletonStack<T> : MonoBehaviour where T : SingletonStack<T>
    {
        static List<T> _stackInstance = new List<T>();

        public static T Current => _stackInstance.Count > 0 ? _stackInstance[^1] : null;

        protected virtual void OnEnable()
        {
            _stackInstance.Add(this as T);
        }

        protected virtual void OnDisable()
        {
            _stackInstance.Remove(this as T);
            if (Current != null) Current.OnEnable();
        }
    }
}