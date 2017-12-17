using UnityEngine;
using System.Collections;
using System;
namespace Afflatus
{
    /// <summary>
    /// 配合 BaseActor
    /// </summary>
    [CreateAssetMenu(fileName = "NewBaseActorData", menuName = "Afflatus/BaseActorData", order = 1)]
    public class BaseActorData : BaseObjectData
    {
        [Header("数值设定")]
        public float MAX_MOVE_SPEED;
        public float MAX_HEALTH;


        [Header("角色当前状态")]
        public float health;
        public ActorMoveState moveState = ActorMoveState.IDLE;

        public override void reset()
        {
            //TODO
        }

        public override void init()
        {
            //TODO
            moveState = ActorMoveState.IDLE;
        }

        public override void unInit()
        {
            //TODO
        }

    }

    public enum ActorMoveState
    {
        IDLE,
        WALK,
        RUN,
        JUMP,
    }
    
}