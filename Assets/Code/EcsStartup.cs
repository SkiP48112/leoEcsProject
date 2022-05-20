using Code.CodeShared.Systems;
using Code.SimpleMovementController.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace Code 
{
    internal sealed class EcsStartup : MonoBehaviour 
    {
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems.ConvertScene();
            
            AddSystems();
            AddOneFrames();
            AddInjections();
        }

        private void AddSystems()
        {
            _systems
                .Add(new GravitySystem())
                .Add(new SimpleControllerInputSystem())
                .Add(new MovementSystem())
                .Init();
        }

        private void AddOneFrames()
        {
        }

        private void AddInjections()
        {
            
        }
        

        private void Update () {
            _systems?.Run ();
        }

        private void OnDestroy ()
        {
            if (_systems == null) 
                return;
            
            _systems.Destroy ();
            _systems = null;
            _world.Destroy ();
            _world = null;
        }
    }
}