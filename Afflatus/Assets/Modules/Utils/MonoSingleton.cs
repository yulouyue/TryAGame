namespace Afflatus
{
    using System;
    using UnityEngine;

    /// <summary>
    /// monobehaviour单例。跨场景不销毁，生命周期最好由管理器控制。
    /// </summary>
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static Component _instance;
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    CreateInstance();
                }
                return (T)_instance;
            }
        }

        public static void CreateInstance()
        {
            lock(_lock)
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (FindObjectsOfType(typeof(T)).Length > 1)
                    {
                        Debug.LogError("CreateInstance: More than 1 monobehaviour singleton found. Check & Reopening the scene might fix it.");
                    }

                    if (_instance == null)
                    {
                        GameObject go = new GameObject();
                        go.name = typeof(T).ToString() +"(AutoCreate)";
                        DontDestroyOnLoad(go);

                        _instance = go.AddComponent<T>();

                    }
                }
            }
        }

        public static void DestroyInstance()
        {
            if (_instance != null)
            {
                MonoBehaviour.Destroy(_instance.gameObject);
            }

            _instance = null;
        }


        private void Awake()
        {
            if (_instance != null && _instance.gameObject != gameObject) //确保单件实例的唯一性
            {
                MonoBehaviour.Destroy(gameObject);

            }
            else if(_instance == null)
            {
                lock (_lock)
                {
                    _instance = this;
                    DontDestroyOnLoad(gameObject);
                    Debug.Log(typeof(T).ToString() + "awake init");

                }
            }
            
        }


        private void OnDestroy()
        {
            if (_instance != null && _instance.gameObject == this.gameObject)
            {
                _instance = null; //确保单件的静态实例会随着GameObject销毁
                UnInit();
            }
        }
        
       

        protected virtual void Init()
        {

        }

        protected virtual void UnInit()
        {
            
        }
    }

}
