using System;
using TMPro;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    private void Update()
    {
        var target = Camera.main;
        var me = transform.position;
        var him = target.transform.position;
        transform.rotation = Quaternion.LookRotation(me - him, Vector3.up);
    }
}