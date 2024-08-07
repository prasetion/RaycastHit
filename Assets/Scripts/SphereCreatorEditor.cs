using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SphereCreator))]
public class SphereCreatorEditor : Editor
{
    private SphereCreator sphereCreator;

    private void OnEnable()
    {
        sphereCreator = (SphereCreator)target;
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Load Spheres"))
        {
            sphereCreator.LoadSpheres();
        }
    }

    private void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            sphereCreator.SaveSpherePositions();
        }
        else if (state == PlayModeStateChange.EnteredEditMode)
        {
            sphereCreator.LoadSpheres();
        }
    }
}
