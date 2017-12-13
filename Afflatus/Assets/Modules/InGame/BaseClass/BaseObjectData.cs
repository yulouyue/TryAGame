using UnityEngine;
using System.Collections;
namespace Afflatus
{
    /// <summary>
    /// 配合 BaseObject
    /// </summary>
    public class BaseObjectData : ScriptableObject
    {
        [SerializeField]
        public long guid;

        
        public virtual void reset() { }
    }
}