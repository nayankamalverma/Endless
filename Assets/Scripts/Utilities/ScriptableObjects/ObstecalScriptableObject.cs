using UnityEngine;

namespace Assets.Scripts.Utilities
{
    [CreateAssetMenu(fileName = "ObstacleScriptableObject", menuName = "ScriptableObject/ObstacleScriptableObject")]
    public class ObstacleScriptableObject : ScriptableObject
    {
        public ObstacleType obstacleType;
        public GameObject prefab;
    }

    public enum ObstacleType
    {
        JumpOverBlock,
        SlideInBlock,
        Truck,
    }
}