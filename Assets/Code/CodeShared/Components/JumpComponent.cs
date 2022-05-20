using System;

namespace Code.CodeShared.Components 
{
    [Serializable]
    public struct JumpComponent
    {
        public float jumpForce;
        public int globalJumpsAmount;
        public int currentJumpsAmount;
    }
}