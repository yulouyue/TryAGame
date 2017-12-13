using UnityEngine;
using System.Collections;
using Afflatus;
public class testCode : MonoBehaviour {

    BaseObject obj;
    BaseObjectData objData;

    private void Start()
    {
        obj = GetComponent<BaseActor>();

        objData = ScriptableObject.CreateInstance<BaseActorData>();
        objData.guid = 123;

        obj.setData(objData);
    }

}
