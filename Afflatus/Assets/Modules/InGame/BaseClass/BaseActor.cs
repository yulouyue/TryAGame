using UnityEngine;
using System.Collections;

namespace Afflatus
{
    /// <summary>
    /// 游戏中所有角色个体的基类
    /// </summary>
    public class BaseActor : BaseObject
    {

        public override void setData(BaseObjectData data)
        {
            if (data is BaseActorData)
            {
                base.setData(data);
            }
            else
            {
                //TODO
            }

        }

        private void Start()
        {
            if(_data && ((BaseActorData)_data).moveState== ActorMoveState.IDLE)
            {
                idle();
            }
        }

        public virtual void idle()
        {

        }
        public virtual void walk()
        {

        }
        public virtual void run()
        {

        }
        public virtual void jump()
        {

        }
        public virtual void die()
        {

        }
    }
}