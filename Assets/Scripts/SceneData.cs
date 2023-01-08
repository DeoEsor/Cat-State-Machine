using System.Collections.Generic;
using DefaultNamespace;
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

    public Transform Home;

    public StateObjectBehavior Hercules;

    public List<Ball> Balls;

    public Ball CurrentBall;
}