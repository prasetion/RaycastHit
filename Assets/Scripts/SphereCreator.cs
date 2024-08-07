using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SphereCreator : MonoBehaviour
{
    public GameObject spherePrefab;
    public SphereData sphereData;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitPosition = hit.point;
                Instantiate(spherePrefab, hitPosition, Quaternion.identity);
                sphereData.positions.Add(hitPosition);
            }
        }
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (!Application.isPlaying && sphereData != null)
        {
            LoadSpheres();
        }
    }

    public void LoadSpheres()
    {
        foreach (Vector3 position in sphereData.positions)
        {
            Instantiate(spherePrefab, position, Quaternion.identity);
        }
    }

    public void SaveSpherePositions()
    {
        // Save positions to the scriptable object
        sphereData.positions.Clear();
        foreach (GameObject sphere in GameObject.FindGameObjectsWithTag("Sphere"))
        {
            sphereData.positions.Add(sphere.transform.position);
        }
        EditorUtility.SetDirty(sphereData);
    }
#endif
}
