using System.Collections.Generic;
using State_Machine;
using UnityEngine;
using UnityEngine.Serialization;


public class SceneData : MonoBehaviour
{
    private SceneData()
    {
        Instance = this;
    }

    public static SceneData Instance { get; set; }

    public LayerMask layerMask;

    public List<Transform> patrolPoints;
    
    public List<Transform> holes;
    
    public Transform cheese;

    public StateObjectBehavior Cat;

    public StateObjectBehavior Rat;
}