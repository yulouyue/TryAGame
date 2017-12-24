using UnityEngine;
using System.Collections;
using TrueSync;
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
                LogUtil.Error(gameObject.name + ": should set 'BaseActorData' rather than 'BaseObjectData'");
            }

        }

        private void Start()
        {
            if(_data == null)
            {
                LogUtil.Error(gameObject.name + " with no data");
            }
        }

        public virtual void idle()
        {
            LogUtil.Error("you should implement BaseActor.idle() on your own!");
        }
        //public virtual void walk()
        //{
        //    LogUtil.Error("you should implement BaseActor.walk() on your own!");

        //}
        public virtual void run(TSVector movingDir)
        {
            LogUtil.Error("you should implement BaseActor.run() on your own!");
        }
        //public virtual void jump()
        //{
        //    LogUtil.Error("you should implement BaseActor.jump() on your own!");
        //}
        public virtual void die()
        {
            LogUtil.Error("you should implement BaseActor.die() on your own!");
        }
        public virtual void lookAt(TSVector mousePosition)
        {
            LogUtil.Error("you should implement BaseActor.lookAt() on your own!");

        }
        public virtual void attack()
        {
            LogUtil.Error("you should implement BaseActor.attack() on your own!");

        }
    }
}