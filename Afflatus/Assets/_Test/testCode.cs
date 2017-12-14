using UnityEngine;
using System.Collections;
using UnityEditor;

using Afflatus;
public class testCode : MonoBehaviour {

    BaseObject obj;
    public BaseActorData objData;

    private void Start()
    {
        obj = GetComponent<BaseActor>();

        //if (objData == null)
        //{
        //    //TODO 把创建数据接口封装到对应的类里面，不要外面调用 ScriptableObject.CreateInstance
        //    objData = ScriptableObject.CreateInstance<BaseActorData>();
        //    objData.guid = 123;
        //    AssetDatabase.CreateAsset(objData, "Assets/_Test/testScriptableObject.asset");
        //    AssetDatabase.SaveAssets();
        //}
        //else
        //{
        //    Debug.Log("already attached so");
        //}
        Debug.Log(objData.guid);
        //obj.setData(objData);
    }

}
