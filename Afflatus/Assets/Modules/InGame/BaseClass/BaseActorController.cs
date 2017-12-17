using UnityEngine;
using System.Collections;
using System;
using TrueSync;
namespace Afflatus
{
    /// <summary>
    /// 输入：来自 TrueSyncBehaviour 的事件
    /// 输出：告诉 BaseActor 应该做出什么行为（不关心具体怎么做）
    /// </summary>
    [RequireComponent(typeof(BaseActor))]
    public class BaseActorController : TrueSyncBehaviour
    {
        [SerializeField]
        private BaseActor _actor;
        //[SerializeField]
        //private bool _isPaused = true;

        void Awake()
        {
            _actor = GetComponent<BaseActor>();
            //_isPaused = true;
        }

        public void StartRunning()
        {
            //_isPaused = false;
        }
        public void StepRunning(object inputParam = null/* TODO 后面要改成具体的结构体 */)
        {
            BaseActorData actorData = _actor.getData() as BaseActorData;
            if (actorData == null)
            {
                return;
            }
            // 状态机逻辑，什么情况下去调用 _actor 的接口
            switch (actorData.moveState)
            {
                case ActorMoveState.IDLE:

                    break;
                case ActorMoveState.JUMP:

                    break;
                case ActorMoveState.WALK:

                    // e.x.
                    //if(inputParam.xxx)
                    //{
                    //    actorData.moveState = ActorMoveState.RUN;
                    //    _actor.run();
                    //}

                    break;
                case ActorMoveState.RUN:

                    break;
            }
        }


        #region TrueSync
        public override void OnSyncedStart()
        {
            StepRunning();//temp
        }

        public override void OnGamePaused()
        {
            StepRunning();//temp
        }
        #endregion

        
        

        
        
    }
}