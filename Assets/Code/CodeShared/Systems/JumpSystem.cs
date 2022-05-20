using Code.CodeShared.Components;
using Code.CodeShared.OneFrames;
using Leopotam.Ecs;

namespace Code.CodeShared.Systems 
{
    sealed class JumpSystem : IEcsRunSystem
    {
        private readonly EcsFilter<JumpEvent, JumpComponent, GravityComponent, GroundCheckSphereComponent> _jumpFilter = null;
        
        void IEcsRunSystem.Run () 
        {
            foreach (var item in _jumpFilter)
            {
                ref var jumpComponent = ref _jumpFilter.Get2(item);
                ref var gravityComponent = ref _jumpFilter.Get3(item);
                ref var groundCheck = ref _jumpFilter.Get4(item);

                if (jumpComponent.currentJumpsAmount < jumpComponent.globalJumpsAmount)
                {
                    gravityComponent.velocity.y = -jumpComponent.jumpForce;
                    jumpComponent.currentJumpsAmount++;
                }
            }
        }
    }
}