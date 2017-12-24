using UnityEngine;
using System.Collections;
namespace Afflatus
{
    /// <summary>
    /// 配合 BaseObject
    /// </summary>
    public abstract class BaseObjectData : ScriptableObject
    {
        public long guid;

        private void OnEnable() //要防止子类调用
        {
            init();
        }
        private void OnDisable() //要防止子类调用
        {
            unInit();
        }


        public abstract void reset();// { }
        public abstract void init();// { }
        public abstract void unInit();// { }
    }

    
}