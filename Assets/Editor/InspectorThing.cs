using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(DamageInfo))]
[CanEditMultipleObjects]
public class InspectorThing : PropertyDrawer
{
    public SerializedProperty WayDamageIsDealt;
    Rect rect;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        rect = new Rect(position.x, position.y, position.width, position.height);
        
        WayDamageIsDealt = property.FindPropertyRelative("WayDamageIsDealt");
        EditorGUI.PropertyField(rect, WayDamageIsDealt);

        switch ((DamageTypes)WayDamageIsDealt.enumValueIndex)
        {
            case DamageTypes.initialOnly:
                string[] firstNames = { "initialDamage", "initialDelay" };
                float index = 20;
                foreach (string name in firstNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + index, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    index += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        index += 10;
                    }
                }
                break;

            case DamageTypes.initialWithBleedSameDamageSameTick:
                string[] secondNames = { "initialDamage", "initialDelay", "bleedDamage", "timeBetweenTicks", "bleedRepeatNumber" };
                float secondIndex = 20;
                foreach (string name in secondNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + secondIndex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    secondIndex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        secondIndex += 10;
                    }
                }
                break;

            case DamageTypes.initialWithBleedManyDamageSameTick:
                string[] thirdNames = { "initialDamage", "initialDelay", "bleedDamageArray", "timeBetweenTicks" };
                float thirdIndex = 20;
                foreach (string name in thirdNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + thirdIndex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    thirdIndex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        thirdIndex += 10;
                    }
                }
                break;

            case DamageTypes.initialWithBleedSameDamageManyTick:
                string[] fourthNames = { "initialDamage", "initialDelay", "bleedDamage", "timeBetweenTicksArray" };
                float fourthIndex = 20;
                foreach (string name in fourthNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + fourthIndex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    fourthIndex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        fourthIndex += 10;
                    }
                }
                break;

            case DamageTypes.initialWithBleedManyDamageManyTick:
                string[] fifthNames = { "initialDamage", "initialDelay", "bleedDamageArray", "timeBetweenTicksArray" };
                float fifthindex = 20;
                foreach (string name in fifthNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + fifthindex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    fifthindex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        fifthindex += 10;
                    }
                }
                break;

            case DamageTypes.bleedOnlySameDamageSameTick:
                string[] sixthNames = { "bleedDamage", "timeBetweenTicks", "bleedRepeatNumber" };
                float sixthIndex = 20;
                foreach (string name in sixthNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + sixthIndex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    sixthIndex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        sixthIndex += 10;
                    }
                }
                break;

            case DamageTypes.bleedOnlyManyDamageSameTick:
                string[] seventhNames = { "bleedDamageArray", "timeBetweenTicks", "bleedRepeatNumber" };
                float seventhIndex = 20;
                foreach (string name in seventhNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + seventhIndex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    seventhIndex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        seventhIndex += 10;
                    }
                }
                break;

            case DamageTypes.bleedOnlySameDamageManyTick:
                string[] eigthNames = { "bleedDamage", "timeBetweenTicksArray", "bleedRepeatNumber" };
                float eigthIndex = 20;
                foreach (string name in eigthNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + eigthIndex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    eigthIndex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        eigthIndex += 10;
                    }
                }
                break;
            case DamageTypes.bleedOnlyManyDamageManyTick:
                string[] ninthNames = { "bleedDamageArray", "timeBetweenTicksArray", "bleedRepeatNumber" };
                float ninthIndex = 20 + position.height;
                foreach (string name in ninthNames)
                {
                    var data = property.FindPropertyRelative(name);
                    rect = new Rect(position.x, position.y + ninthIndex, position.width, position.height);
                    EditorGUI.PropertyField(rect, data, true);
                    ninthIndex += position.height * data.CountInProperty();
                    if (data.isArray)
                    {
                        ninthIndex += 10;
                    }   
                }
                break;
        }
        EditorGUI.EndProperty();
    }
}
