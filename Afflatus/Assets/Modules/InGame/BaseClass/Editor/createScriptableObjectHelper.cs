using UnityEngine;
using System.Collections;
using Afflatus;
using UnityEditor;
using System.IO;

/// <summary>
/// 菜单创建 ScriptableObject ，  可以直接在对应 ScriptableObject 类前加修饰 CreateAssetMenu
/// </summary>
public class ScriptableObjectHelper {

 //   [MenuItem("Assets/Create/BaseActorData(ScriptableObject)")]
	//public static void createScriptableObject()
 //   {
 //       BaseActorData dataAsset = ScriptableObject.CreateInstance<BaseActorData>();

        
 //       AssetDatabase.CreateAsset(dataAsset, AssetDatabase.GenerateUniqueAssetPath(getCurrentSelectedObjectPath() + "/New MyAsset.asset"));
 //       AssetDatabase.SaveAssets();

 //       EditorUtility.FocusProjectWindow();
 //       Selection.activeObject = dataAsset;
 //   }


 //   private static string getCurrentSelectedObjectPath()
 //   {
 //       string path = AssetDatabase.GetAssetPath(Selection.activeObject);
 //       if (path == "")
 //       {
 //           path = "Assets";
 //       }
 //       else if (Path.GetExtension(path) != "")
 //       {
 //           path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), "");
 //       }
 //       return path;
 //   }

}
