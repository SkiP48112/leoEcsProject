using System;
using UnityEngine;

namespace Code.CodeShared.Components 
{
    [Serializable]
    public struct GroundCheckSphereComponent
    {
        public LayerMask groundMask;
        public Transform groundCheckSphere;
        public float groundDistance;
        public bool isGrounded;
    }
}