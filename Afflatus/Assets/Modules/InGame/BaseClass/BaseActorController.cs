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
    [RequireComponent(typeof(TSRigidBody))]
    [RequireComponent(typeof(TSTransform))]
    public class BaseActorController : TrueSyncBehaviour
    {
        [SerializeField]
        private BaseActor _actor;

        private TSVector _mousePosition;
        private bool     _mouseClicked;
        private string  _keyPressed;

        //TODO 后面用状态机改造，不要switch-case，参考 http://wiki.unity3d.com/index.php?title=Finite_State_Machine
        //private FSMState _curState;
        //private FSM fsm; 
        private ActorMoveState _movingState;


        void Awake()
        {
            if(_actor == null)
                _actor = GetComponent<BaseActor>();
            
        }
        
        public void startRunning()
        {
            BaseActorData actorData = _actor.getData() as BaseActorData;
            _movingState = actorData.moveState;
        }

        public void StepRunning( /* object inputParam = null TODO 后面要改成具体的结构体 */)
        {
            // 移动
            switch (_movingState)
            {
                case ActorMoveState.IDLE:
                    if(isWASD(_keyPressed))
                    {
                        _movingState = ActorMoveState.RUN;
                        if (_keyPressed.Equals("w"))
                        {
                            _actor.run(TSVector.forward);
                        }
                        else if (_keyPressed.Equals("s"))
                        {
                            _actor.run(TSVector.back);
                        }
                        else if (_keyPressed.Equals("a"))
                        {
                            _actor.run(TSVector.left);
                        }
                        else if (_keyPressed.Equals("d"))
                        {
                            _actor.run(TSVector.right);
                        }
                    }
                    else
                    {
                        _actor.idle();
                    }
                    
                    break;
                case ActorMoveState.JUMP:

                    break;
                case ActorMoveState.WALK:
                    
                    break;
                case ActorMoveState.RUN:
                    if(_keyPressed.Equals("w"))
                    {
                        _actor.run(TSVector.forward);
                    }
                    else if (_keyPressed.Equals("s"))
                    {
                        _actor.run(TSVector.back);
                    }
                    else if (_keyPressed.Equals("a"))
                    {
                        _actor.run(TSVector.left);
                    }
                    else if (_keyPressed.Equals("d"))
                    {
                        _actor.run(TSVector.right);
                    }
                    else if (string.IsNullOrEmpty(_keyPressed))
                    {
                        _movingState = ActorMoveState.IDLE;
                    }
                    
                    break;
            }

            //转向
            _actor.lookAt(_mousePosition);

            //开火
            if(_mouseClicked)
            {
                _mouseClicked = false;
                _actor.attack();
            }

        }


        #region TrueSync
        private byte MOUSE_X = 0;
        private byte MOUSE_Y = 1;
        private byte MOUSE_CLICK = 2;
        private byte KEY_PRESS = 3;

        private float camRayLenth = 100f;
        public override void OnSyncedInput()
        {
            //鼠标位置用于枪口朝向
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, camRayLenth))//记得floor上要加meshcollider。。。
            {
                TrueSyncInput.SetFP(MOUSE_X, (FP)hit.point.x);
                TrueSyncInput.SetFP(MOUSE_Y, (FP)hit.point.z);

            }

            //鼠标点击用于开枪
            if (Input.GetMouseButtonDown(0)/*left button*/)
            {
                TrueSyncInput.SetBool(MOUSE_CLICK, true);
            }

            //键盘按键用于行走
            if(!string.IsNullOrEmpty(Input.inputString))
            {
                TrueSyncInput.SetString(KEY_PRESS, Input.inputString);
            }
        }

        public override void OnSyncedStart()
        {
            startRunning();
        }

        public override void OnSyncedUpdate()
        {
            _mousePosition.x = TrueSyncInput.GetFP(MOUSE_X);
            _mousePosition.z = TrueSyncInput.GetFP(MOUSE_Y);


            _mouseClicked = TrueSyncInput.GetBool(MOUSE_CLICK);
            _keyPressed = TrueSyncInput.GetString(KEY_PRESS);

            StepRunning();
        }

        

        public void OnSyncedCollisionEnter(TSCollision other)
        {
            BaseObject baseObj = other.gameObject.GetComponent<BaseObject>();
            if(baseObj)
            {
                if (baseObj.type == ObjectType.ITEM)
                {
                    //调用吃道具效果
                }
                else if (baseObj.type == ObjectType.ENV)
                {
                    //调用触碰环境效果
                }
            }
            else
            {
                //LogUtil.Debug(gameObject.name + " collide with " + other.gameObject.name + "(no BaseObject.type)");
            }
            
        }
        #endregion


        //临时
        private bool isWASD(string keyString="")
        {
            if(keyString.Equals("w")|| keyString.Equals("a") || keyString.Equals("s") || keyString.Equals("d"))
            {
                return true;
            }
            return false;
        }


    }
}