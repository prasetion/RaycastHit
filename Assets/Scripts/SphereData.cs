using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SphereData", menuName = "ScriptableObjects/SphereData", order = 1)]
public class SphereData : ScriptableObject
{
    public List<Vector3> positions = new List<Vector3>();
}
