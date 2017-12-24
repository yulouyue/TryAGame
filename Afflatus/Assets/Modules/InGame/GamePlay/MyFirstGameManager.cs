using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TrueSync;

namespace Afflatus
{
    /// <summary>
    /// 一个GameManager一种玩法，这里是demo，简单设置了游戏的开始和结束规则
    /// </summary>
    public class MyFirstGameManager : MonoSingleton<MyFirstGameManager>
    {
        public TrueSyncManager tsManager;
        private List<BaseActorController> players;


        private void Awake()
        {
            tsManager = GetComponent<TrueSyncManager>();
            if (tsManager == null)
                LogUtil.Error("没有 TrueSyncManager");
        }

        public void onMyGamePrepare()
        {
            //注册玩家（TrueSync有记录，但我们要用自己的）
            players = new List<BaseActorController>();
            //TrueSyncManager.getAllPlayers, add to players
            //或者，继承TrueSyncBehaviour的控制器自己上报，非继承TrueSyncBehaviour的也要上报，两个放在不同的列表里。
            //为了强制，可以规定一个接口，所有controller都要继承，即自动上报到列表

            //摆放玩家位置

        }
        public void onMyGameStart()
        {

        }


        public void onMyGameEnd()
        {

        }


    }
}