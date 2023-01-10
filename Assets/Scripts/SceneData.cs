using System;
using System.Collections.Generic;
using StarterAssets;
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
    
    public StateObjectBehavior DevOps;

    public Client client;

    public Transform bad;

    public Transform monitor;


    public float tired = 0;
    public float clientAngry = 28;
    public float timeSpendWithoutMonitor = 0;
    public float procentageOfWreckedCode = 0;
    public float readyOfPatch = 50;
}