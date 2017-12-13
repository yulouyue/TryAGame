using UnityEngine;
using System.Collections;
namespace Afflatus
{
    /// <summary>
    /// 游戏中所有可交互对象的基类
    /// </summary>
    public abstract class BaseObject : MonoBehaviour
    {
        [SerializeField]
        protected BaseObjectData _data;

        public virtual void reset()
        {
            if (_data)
                _data.reset();
        }

        public virtual void setData(BaseObjectData data)
        {
            if(data != null)
            {
                _data = data;
            }
            else
            {
                // TODO
            }
            
        }

        public virtual BaseObjectData getData()
        {
            return _data;
        }
        
    }
}