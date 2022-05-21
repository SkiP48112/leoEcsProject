using Code.CodeShared.Components;
using Code.CodeShared.Tags;
using Code.SimpleMovementController.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.SimpleMovementController.Systems 
{
    sealed class SimpleControllerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, SimpleMovementControllerTag, DirectionComponent, AnimationComponent, ModelComponent>
            _simpleControllerFilter = null;

        private static readonly int Run1 = Animator.StringToHash("run");

        void IEcsRunSystem.Run ()
        {
            var inputHorizontal = Input.GetAxis("Horizontal");
            foreach (var item in _simpleControllerFilter)
            {
                
                ref var animationComponent = ref _simpleControllerFilter.Get4(item);
                ref var directionComponent = ref _simpleControllerFilter.Get3(item);
                ref var modelComponent = ref _simpleControllerFilter.Get5(item);

                if (inputHorizontal > 0)
                {
                    modelComponent.transform.rotation = new Quaternion(0, 0, 0, 1);
                }
                else if(inputHorizontal < 0)
                {
                    modelComponent.transform.rotation = new Quaternion(0, -180, 0, 1);
                }
                
                animationComponent.animator.SetBool(Run1, inputHorizontal != 0);
                
                directionComponent.direction = new Vector2(inputHorizontal, 0);
            }
        }
    }
}