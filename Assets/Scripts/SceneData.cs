using DefaultNamespace;
using State_Machine;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    private SceneData()
    {
        Instance = this;
    }

    public static SceneData Instance { get; set; }

    public Player player;

    public StateObjectBehavior monster;

    public Transform spawn;
    
    public Transform food;
}