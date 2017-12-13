using UnityEngine;
using System.Collections;
using Afflatus;
public class testCode : MonoBehaviour {

    BaseObject obj;
    BaseObjectData objData;

    private void Start()
    {
        obj = GetComponent<BaseActor>();

        //TODO 把创建数据接口封装到对应的类里面，不要外面调用 ScriptableObject.CreateInstance
        objData = ScriptableObject.CreateInstance<BaseActorData>();
        objData.guid = 123;

        obj.setData(objData);
    }

}
