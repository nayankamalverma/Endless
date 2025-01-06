using System.Collections.Generic;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class ObstaclesController : MonoBehaviour
    {
        [SerializeField] List<ObstacleScriptableObject> obstaclesList;


        

        private ObstacleType GetRandomObstacle()
        {
            return obstaclesList[Random.Range(0, obstaclesList.Count)].obstacleType;
        }

        
    }
}