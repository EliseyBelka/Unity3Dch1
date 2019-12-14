using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(TestScript))]
public class MyScriptЕditor : Editor
{
    bool _isPressButtonOk;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TestScript testTarget = (TestScript)target;

        var isPressButton = GUILayout.Button("Создание объектов по кнопке", EditorStyles.miniButton);

        if (isPressButton)
        {
            testTarget.CreateObj();
            _isPressButtonOk = true;
        }

        if (_isPressButtonOk)
        {
            EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);
        }
    }
}
