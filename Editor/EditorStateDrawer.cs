using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(SimpleAnimation.EditorState))]
class EditorStateDrawer : PropertyDrawer
{
    class Styles
    {
        public static readonly GUIContent disabledTooltip = new GUIContent("", "The Default state cannot be edited, change the Animation clip to change the Default State");
    }

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        EditorGUILayout.BeginHorizontal();
        // Calculate rects
        Rect clipRect = new Rect(position.x, position.y, position.width/2 - 5, position.height);
        Rect nameRect = new Rect(position.x + position.width/2 + 5, position.y, position.width/2 - 5, position.height);


        // EditorGUI.BeginDisabledGroup(property.FindPropertyRelative("defaultState").boolValue);
        // EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("clip"), GUIContent.none);
        // EditorGUI.PropertyField(clipRect, property.FindPropertyRelative("name"), GUIContent.none);
        // if (property.FindPropertyRelative("defaultState").boolValue)
        // {
        //     EditorGUI.LabelField(position, Styles.disabledTooltip);
        // }

        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("clip"), GUIContent.none);
        bool readOnly = property.FindPropertyRelative("readOnly").boolValue;
        EditorGUI.BeginDisabledGroup(readOnly);
        EditorGUI.PropertyField(clipRect, property.FindPropertyRelative("name"), GUIContent.none);
        if (readOnly)
        {
            EditorGUI.LabelField(position, Styles.disabledTooltip);
        }

        EditorGUI.EndDisabledGroup();

        EditorGUILayout.EndHorizontal();
        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
}
