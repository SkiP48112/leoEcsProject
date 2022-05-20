using Code.CodeShared.Components;
using Code.CodeShared.OneFrames;
using Code.CodeShared.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.CodeShared.Systems
{
    sealed class JumpEventSenderSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, JumpComponent> _jumpEventFilter = null;
        
        void IEcsRunSystem.Run () 
        {
            if(!Input.GetKeyDown(KeyCode.Space))
                return;
            
            foreach (var item in _jumpEventFilter)
            {
                ref var entity = ref _jumpEventFilter.GetEntity(item);
                entity.Get<JumpEvent>();
            }
        }
    }
}