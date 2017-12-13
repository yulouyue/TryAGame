namespace Afflatus
{
    /// <summary>
    /// c#单例模版类，通过管理器显式创建、销毁。
    /// </summary>
    public class CsSingleton<T> where T : class, new()
    {

        private static T _instance;

        protected CsSingleton(){ }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    CreateInstance();
                }

                return _instance;
            }

            protected set
            {
                _instance = value;
            }
        }


        // 创建单例
        public static void CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new T();

                (_instance as CsSingleton<T>).Init();
            }
        }


        // 删除单例
        public static void DestroyInstance()
        {
            if (_instance != null)
            {
                (_instance as CsSingleton<T>).UnInit();
                _instance = null;
            }
        }
        

        public virtual void Init()
        {
        }


        public virtual void UnInit()
        {
        }
    }
}
