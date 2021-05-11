using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class My_Tool : EditorWindow
{
    string Object_Name = "";
    int ObjectID = 1;
    GameObject objectToSpawn;
    float objectScale;
    float spawnRadius = 5f;

    [MenuItem("Tools/My_Tool")]

    public static void Show()
    {
        GetWindow(typeof(My_Tool));
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn Object", EditorStyles.boldLabel);

        Object_Name = EditorGUILayout.TextField("Base Name", Object_Name);
        ObjectID = EditorGUILayout.IntField("ID", ObjectID);
        objectScale = EditorGUILayout.Slider("Scale", objectScale, 0.5f, 3f);
        spawnRadius = EditorGUILayout.FloatField("Radius", spawnRadius);
        objectToSpawn = EditorGUILayout.ObjectField("Prefab", objectToSpawn, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Spawn Object"))
        {
            Spawn();
        }

    }

    private void Spawn()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Error: No object assigned.");
            return;
        }

        if (Object_Name == string.Empty)
        {
            Debug.LogError("Give it a name");
            return;
        }

        Vector2 SpawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 Position = new Vector3(SpawnCircle.x, 0f, SpawnCircle.y);

        GameObject New_Object = Instantiate(objectToSpawn, Position, Quaternion.identity);
        New_Object.name = Object_Name + ObjectID;
        New_Object.transform.localScale = Vector3.one * objectScale;

        objectScale++;
    }

}
