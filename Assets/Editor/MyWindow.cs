using UnityEditor;
using UnityEngine;

namespace RollBall
{
    public class MyWindow : EditorWindow
    {
        public static GameObject ObjectInstantiate;
        public string nameObject = "Bonuses";
        public bool groupEnabled;
        public bool simple = true;
        public int countObject = 1;
        public float distance = 1;
        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            ObjectInstantiate = EditorGUILayout.ObjectField("Объект", ObjectInstantiate, typeof(GameObject), true) as GameObject;
            nameObject = EditorGUILayout.TextField("Имя объекта", nameObject);
            groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
            simple = EditorGUILayout.Toggle("Просто переключатель", simple);
            countObject = EditorGUILayout.IntSlider("Количество объектов", countObject, 1, 20);
            distance = EditorGUILayout.Slider("Дистанция между объектами", distance, 1, 10);
            EditorGUILayout.EndToggleGroup();
            var button = GUILayout.Button("Создать объекты");
            if (button)
            {
                if (ObjectInstantiate)
                {
                    GameObject root = new GameObject("New objects");
                    for (int i = 0; i < countObject; i++)
                    {
                        float angle = i * Mathf.PI * 2 / countObject;
                        Vector3 pos = new Vector3(i * distance, 0.5f , 0);
                        GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
                        temp.name = nameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        if (simple)
                        {
                            Debug.Log("Просто переключатель включен");
                        }
                    }
                }
            }
        }
    }
}

