using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DamageInfo))]
[CanEditMultipleObjects]
public class InspectorThing : PropertyDrawer
{

    public DamageTypes type;


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        var rect = new Rect(position.x, position.y, position.width, position.height);
        type = (DamageTypes)EditorGUI.EnumPopup(rect,type);

        switch (type)
        {
            case DamageTypes.bleedOnly:
                var t = property.FindPropertyRelative("bleedDamage");
                var otherRect = new Rect(position.x, position.y, position.width, position.height);
                EditorGUI.PropertyField(otherRect, t);
                break;

            case DamageTypes.initialOnly:
                var ert = property.FindPropertyRelative("timeBetweenBleeds");
                var second = property.FindPropertyRelative("bleedRepeatNumber");
                var amountRect = new Rect(position.x, position.y + 20, position.width, position.height);
                var secondAmountRect = new Rect(position.x, position.y + 40, position.width, position.height);
                EditorGUI.PropertyField(amountRect, ert);
                EditorGUI.PropertyField(secondAmountRect, second);
                break;

            case DamageTypes.initialWithBleed:
                var ertee = property.FindPropertyRelative("numberOfBleedTicks");
                var firstRect = new Rect(position.x, position.y, position.width, position.height);
                EditorGUI.PropertyField(firstRect, ertee);
                break;
        }
        EditorGUI.EndProperty();
    }
}
