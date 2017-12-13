using UnityEngine;
using System.Collections;
namespace Afflatus
{
    /// <summary>
    /// 游戏中所有物件的基类
    /// </summary>
    public class BaseItem : BaseObject
    {

        public override void setData(BaseObjectData data)
        {
            if (data is BaseItemData)
            {
                base.setData((BaseItemData)data);
            }
            else
            {
                //TODO
            }
        }

    }
}