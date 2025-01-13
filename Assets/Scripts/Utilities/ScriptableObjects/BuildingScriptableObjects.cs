using Assets.Scripts.Utilities;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingScriptableObjects", menuName = "ScriptableObject/BuildingScriptableObjects")]
public class BuildingScriptableObjects : ScriptableObject
{
    public BuildingType buildingType;
    public GameObject prefab;
}

public enum BuildingType
{
   B1,
   B2,
   B3,
}
