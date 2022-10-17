using UnityEditor;
using UnityEngine;

namespace RollBall
{
    [CustomEditor(typeof(TestBehaviour))]
    public class TestBehaviourEditor : UnityEditor.Editor
    {
        private bool isPressButtonOk;
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            TestBehaviour testTarget = (TestBehaviour)target;
            testTarget.count = EditorGUILayout.IntSlider(testTarget.count, 10, 50);
            testTarget.offset = EditorGUILayout.IntSlider(testTarget.offset, 1, 5);
            testTarget.obj =
            EditorGUILayout.ObjectField("Объект который хотим вставить", testTarget.obj, typeof(GameObject), false)
            as GameObject;
            var isPressButton = GUILayout.Button("Создание объектов по кнопке", EditorStyles.miniButtonLeft);
            isPressButtonOk = GUILayout.Toggle(isPressButtonOk, "Ok");
            if (isPressButton)
            {
                testTarget.CreateObj();
                isPressButtonOk = true;
            }
            if (isPressButtonOk)
            {
                testTarget.Test = EditorGUILayout.Slider(testTarget.Test, 10, 50);
                EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
                var isPressAddButton = GUILayout.Button("Add Collider", EditorStyles.miniButtonLeft);
                var isPressRemoveButton = GUILayout.Button("Remove Collider", EditorStyles.miniButtonLeft);
                if (isPressAddButton)
                {
                    testTarget.AddComponent();
                }
                if (isPressRemoveButton)
                {
                    testTarget.RemoveComponent();
                }
            }
        }
    }
}