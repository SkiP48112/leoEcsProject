using Code.CodeShared.Components;
using Code.CodeShared.OneFrames;
using Code.CodeShared.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.CodeShared.Systems 
{
    sealed class GroundCheckSystem : IEcsRunSystem
    {

        private readonly EcsFilter<GroundCheckSphereComponent> _groundFilter = null;
        
        void IEcsRunSystem.Run ()
        {
            foreach (var item in _groundFilter)
            {
                ref var groundCheck = ref _groundFilter.Get1(item);
                ref var entity = ref _groundFilter.GetEntity(item);

                groundCheck.isGrounded =
                    Physics.CheckSphere(groundCheck.groundCheckSphere.position, groundCheck.groundDistance,
                        groundCheck.groundMask);

                if (entity.Has<JumpComponent>() && groundCheck.isGrounded && !entity.Has<JumpEvent>())
                {
                    ref var jumpComponent = ref entity.Get<JumpComponent>();
                    jumpComponent.currentJumpsAmount = 0;
                }
                    
            }
        }
    }
}