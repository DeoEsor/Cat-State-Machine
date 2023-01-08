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

    public List<Transform> patrolPoints;

    public StateObjectBehavior Fly;

    public GameObject Player;

    public Transform EatPlace;
}