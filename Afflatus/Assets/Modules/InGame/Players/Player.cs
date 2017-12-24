using UnityEngine;
using System.Collections;
using DG.Tweening;
using TrueSync;
namespace Afflatus
{
    public class Player : BaseActor
    {
        public GameObject footPrintPrefab;
        public Transform skin;

        public DOTweenAnimation idleAnim;
        public DOTweenAnimation runAnim;
        public DOTweenAnimation dieAnim;

        //private Vector3 footPrintPos = new Vector3(0, -4, -4);

        public override void attack()
        {
            LogUtil.Debug("射出一发子弹");
        }

        public override void lookAt(TSVector mousePosition)
        {
            if(tsTransform != null)
            {
                TSVector facingDir = mousePosition - tsTransform.position;
                facingDir.y = 0;

                TSQuaternion rot = TSQuaternion.LookRotation(facingDir);
                //tsTransform.rotation = rot;
                tsRigidBody.MoveRotation(rot);
            }
        }

        public override void run(TSVector movingDir)
        {
            //LogUtil.Debug("run");
            (_data as BaseActorData).moveState = ActorMoveState.RUN;

            //位移
            if(tsRigidBody != null)
            {
                TSVector movement = movingDir * (_data as BaseActorData).MAX_MOVE_SPEED /** TrueSyncManager.DeltaTime*/;
                //tsRigidBody.position += movement;
                tsRigidBody.velocity = movement;
            }

            //动画
            if (idleAnim && idleAnim.hasOnPlay)
            {
                idleAnim.DOPause();
            }
            if (dieAnim && dieAnim.hasOnPlay)
            {
                dieAnim.DOPause();
            }

            if (runAnim && !runAnim.hasOnPlay)
            {
                runAnim.DOPlay();
                //Transform footPrint = Instantiate(footPrintPrefab, Vector3.zero, Quaternion.identity) as Transform;
                //footPrint.SetParent(gameObject.transform);
                //footPrint.SetAsFirstSibling();
                //footPrint.localPosition = footPrintPos;
            }

        }

        public override void idle()
        {
            (_data as BaseActorData).moveState = ActorMoveState.IDLE;

            if (runAnim && runAnim.hasOnPlay)
            {
                runAnim.DOPause();
            }
            if (dieAnim&& dieAnim.hasOnPlay)
            {
                dieAnim.DOPause();
            }

            if (idleAnim && !idleAnim.hasOnPlay)
            {
                //idleAnim.DOPlay();
            }
        }

        public override void die()
        {

            if (idleAnim&& idleAnim.hasOnPlay)
            {
                idleAnim.DOPause();
            }
            if (runAnim&& runAnim.hasOnPlay)
            {
                runAnim.DOPause();
            }

            if (dieAnim&& !dieAnim.hasOnPlay)
            {
                dieAnim.DOPlay();
            }

        }


    }
}