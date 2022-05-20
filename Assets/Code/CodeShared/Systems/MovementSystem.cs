using Code.CodeShared.Components;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

namespace Code.CodeShared.Systems 
{
    sealed class MovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<MovableComponent, DirectionComponent, TransformComponent> _movableFilter = null;
        
        
        void IEcsRunSystem.Run () 
        {
            foreach (var item in _movableFilter)
            {
                ref var movableComponent = ref _movableFilter.Get1(item);
                ref var directionComponent = ref _movableFilter.Get2(item);
                ref var transformComponent = ref _movableFilter.Get3(item);
                
                transformComponent.transform.Translate(movableComponent.movementSpeed * directionComponent.direction * Time.deltaTime);
            }
        }
    }
}