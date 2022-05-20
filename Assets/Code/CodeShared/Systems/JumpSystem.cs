using Client;
using Code.CodeShared.Components;
using Leopotam.Ecs;

namespace Code.CodeShared.Systems 
{
    sealed class JumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<JumpEvent, JumpComponent, GravityComponent> _jumpFilter = null;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var item in _jumpFilter)
            {
                ref var jumpComponent = ref _jumpFilter.Get2(item);
                ref var gravityComponent = ref _jumpFilter.Get3(item);

                gravityComponent.velocity.y = -jumpComponent.jumpForce;
            }
        }
    }
}