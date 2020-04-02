using UnityEngine;
using UnityEditor;

public class NewWindow : EditorWindow
{
    //Object
    GameObject prefab;
    //Spawn Location
    Transform local;


    [MenuItem("Window/Prefab")]
    //Opens Window
    public static void OpenWindow()
    {
        EditorWindow.GetWindow(typeof(NewWindow));
    }
    private void OnGUI()
    {
        //Press to Spawn Sphere
        if (GUILayout.Button("Spawner"))
        {
            GameObject.Instantiate(prefab.transform, local.position, local.rotation);
        }
        //Adds object field to Window
        prefab = (GameObject)EditorGUILayout.ObjectField(prefab, typeof(GameObject), true);
        //Add Location field into window
        local = (Transform)EditorGUILayout.ObjectField(local, typeof(Transform), true);
    }
}
