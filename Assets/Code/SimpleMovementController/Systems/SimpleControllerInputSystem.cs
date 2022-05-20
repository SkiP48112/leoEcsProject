using Code.CodeShared.Components;
using Code.SimpleMovementController.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.SimpleMovementController.Systems 
{
    sealed class SimpleControllerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, SimpleMovementControllerTag, DirectionComponent>
            _simpleControllerFilter = null;
        
        void IEcsRunSystem.Run ()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            foreach (var item in _simpleControllerFilter)
            {
                ref var directionComponent = ref _simpleControllerFilter.Get3(item);

                directionComponent.direction = new Vector2(inputHorizontal, 0);
            }
        }
    }
}