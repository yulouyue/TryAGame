using UnityEngine;
using System.Collections;
using DG.Tweening;
namespace Afflatus
{
    public class Player : BaseActor
    {
        public GameObject footPrintPrefab;
        public Transform skin;

        public DOTweenAnimation idleAnim;

        private Vector3 footPrintPos = new Vector3(0, -4, -4);

        public override void run()
        {
            base.run();
            Transform footPrint = Instantiate(footPrintPrefab, Vector3.zero, Quaternion.identity) as Transform;
            footPrint.SetParent(gameObject.transform);
            footPrint.SetAsFirstSibling();
            footPrint.localPosition = footPrintPos;
        }

        public override void idle()
        {
            base.idle();
            if(!idleAnim.hasOnPlay)
            {
                idleAnim.DOPlay();
            }
        }

    }
}