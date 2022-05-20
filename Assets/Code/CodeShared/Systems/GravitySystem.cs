using Code.CodeShared.Components;
using Code.CodeShared.OneFrames;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.CodeShared.Systems 
{
    sealed class GravitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<GravityComponent, TransformComponent, GroundCheckSphereComponent> _gravityFilter = null;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var item in _gravityFilter)
            {
                ref var gravityComponent = ref _gravityFilter.Get1(item);
                ref var transformComponent = ref _gravityFilter.Get2(item);
                ref var groundCheck = ref _gravityFilter.Get3(item);
                ref var entity = ref _gravityFilter.GetEntity(item);
                if (!entity.Has<JumpEvent>())
                    gravityComponent.velocity.y += gravityComponent.gravityForce * Time.deltaTime;

                if (groundCheck.isGrounded && !entity.Has<JumpEvent>())
                    gravityComponent.velocity.y = 0;
                transformComponent.transform.Translate(-gravityComponent.velocity * Time.deltaTime);
            }
        }
    }
}