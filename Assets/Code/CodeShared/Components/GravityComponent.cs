using System;
using UnityEngine;

namespace Code.CodeShared.Components 
{
    [Serializable]
    public struct GravityComponent
    {
        public float gravityForce;
        public Vector2 velocity;
    }
}