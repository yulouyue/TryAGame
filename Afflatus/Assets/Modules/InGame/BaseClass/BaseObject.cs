using UnityEngine;
using System.Collections;
using TrueSync;

namespace Afflatus
{
    /// <summary>
    /// 通过type判断是道具？环境？敌人？
    /// </summary>
    public enum ObjectType
    {
        ENV,
        ITEM,
        ENEMY,
        NEUTRAL,
        ALLY,
    }

    /// <summary>
    /// 游戏中所有可交互对象的基类
    /// </summary>
    public abstract class BaseObject : MonoBehaviour
    {
        public ObjectType type = ObjectType.NEUTRAL;//要不要放到 _data中去呢，先这样


        [SerializeField]
        protected BaseObjectData _data;

        protected TSRigidBody tsRigidBody
        {
            get
            {
                if(_tsRigidBody == null)
                {
                    _tsRigidBody = GetComponent<TSRigidBody>();
                }
                return _tsRigidBody;
            }
        }
        protected TSTransform tsTransform
        {
            get
            {
                if (_tsTransform == null)
                {
                    _tsTransform = GetComponent<TSTransform>();
                }
                return _tsTransform;
            }
        }

        private TSRigidBody _tsRigidBody;
        private TSTransform _tsTransform;

        public virtual void reset()
        {
            if (_data)
                _data.reset();
        }

        public virtual void setData(BaseObjectData d)
        {
            if(d != null)
            {
                _data = d;
            }
            else
            {
                LogUtil.Error(gameObject.name + ": setData with null");
            }
            
        }

        public virtual BaseObjectData getData()
        {
            return _data;
        }
        
    }
}