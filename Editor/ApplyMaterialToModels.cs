using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

public class ApplyMaterialToModels : EditorWindow {
    private Material material;

    [MenuItem("Tools/ApplyMaterialToModels")]
    private static void ShowWindow() {
        ApplyMaterialToModels window = GetWindow<ApplyMaterialToModels>();
        window.titleContent = new GUIContent("Apply Material");
        window.Show();
    }

    private void OnGUI() {
        EditorGUILayout.HelpBox("Select the Material to Apply", MessageType.Info);
        material = EditorGUILayout.ObjectField("Material", material, typeof(Material), false) as Material;

        if (GUILayout.Button("Apply")) {
            GameObject[] selectedObjects = Selection.gameObjects;

            if (selectedObjects.Length > 0 && material != null) {
                foreach (GameObject obj in selectedObjects) {
                    Renderer renderer = obj.GetComponent<Renderer>();

                    if (renderer != null) {
                        Undo.RecordObject(renderer, "Apply Material");
                        renderer.sharedMaterial = material;
                        EditorUtility.SetDirty(renderer);
                    }
                }
            }
        }
    }
}

#endif