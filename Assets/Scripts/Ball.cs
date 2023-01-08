using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Ball : MonoBehaviour
    {
        public float RollingScale = 1;
        public bool IsRolling;
        public GameObject model;

        private void Update()
        {
            if (!IsRolling) return;
            RollingScale += Time.deltaTime;
            RollingScale = Mathf.Clamp(RollingScale, 1, 18);
            model.transform.localScale = Vector3.one * (RollingScale * 0.1f + 0.2f);
            model.transform.RotateAround(transform.position, 1);
        }
    }
}