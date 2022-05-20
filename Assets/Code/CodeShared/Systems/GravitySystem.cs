using Code.CodeShared.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.CodeShared.Systems 
{
    sealed class GravitySystem : IEcsRunSystem
    {
        private readonly EcsFilter<GravityComponent, TransformComponent> _gravityFilter = null;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var item in _gravityFilter)
            {
                ref var gravityComponent = ref _gravityFilter.Get1(item);
                ref var transformComponent = ref _gravityFilter.Get2(item);
                gravityComponent.velocity.y += gravityComponent.gravityForce * Time.deltaTime;
                transformComponent.transform.Translate(-gravityComponent.velocity * Time.deltaTime);
            }
        }
    }
}