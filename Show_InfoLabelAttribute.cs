
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[System.AttributeUsage(System.AttributeTargets.Field)]
public class Show_InfoLabelAttribute : PropertyAttribute {
	public readonly string[] labels;

	public Show_InfoLabelAttribute(params string[] labels) {
		this.labels = labels;
	}
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(Show_InfoLabelAttribute))]
public class Show_CustomLabelAttribute_Drawer : PropertyDrawer {
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
		Show_InfoLabelAttribute attr = attribute as Show_InfoLabelAttribute;
		return base.GetPropertyHeight(property, label) * attr.labels.Length;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
		Show_InfoLabelAttribute attr = attribute as Show_InfoLabelAttribute;
		for (int i = 0; i < attr.labels.Length; i++) {
			EditorGUI.LabelField(position, attr.labels[i]);
			position.y += position.height;
		}
		//        EditorGUI.PropertyField(position, property, label);
	}
}
#endif
