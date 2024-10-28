using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Squirrel.Extension
{
    public class TaskListController : MonoBehaviour
    {
        public Dictionary<string, Action> dictCallBack = new Dictionary<string, Action>();

        static TaskListController gInstance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject g = new GameObject();
                    g.name = "TaskListController Auto Create";
                    _instance = g.AddComponent<TaskListController>();
                }

                return _instance;
            }
        }

        private static TaskListController _instance;

        public static void AddTask(MonoBehaviour monoBehaviour, string key, Action callBack)
        {
            gInstance.DoAddTask(key + monoBehaviour.GetInstanceID(), callBack);
        }

        public static void AddTask(string key, Action callBack)
        {
            gInstance.DoAddTask(key, callBack);
        }

        void DoAddTask(string key, Action callBack)
        {
            if (dictCallBack.ContainsKey(key)) return;
            dictCallBack.Add(key, callBack);
            if (_coroutineRunTask != null) StopCoroutine(_coroutineRunTask);
            _coroutineRunTask = StartCoroutine(corouRunTask());
        }

        private Coroutine _coroutineRunTask;

        IEnumerator corouRunTask()
        {
            yield return new WaitForEndOfFrame();
            foreach (KeyValuePair<string, Action> keyValuePair in dictCallBack)
            {
                Debug.Log("Do Task: " + keyValuePair.Key);
                keyValuePair.Value?.Invoke();
            }

            dictCallBack = new Dictionary<string, Action>();
        }
    }
}