using NS.GameEventsScripts;
using NS.PlayerControllerScripts;
using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GlobalGameSettings _gameSettings;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _playerMovementSpeed;
    [SerializeField] private Transform _player;

    private GameEvents _gameEvents;
    private PlayerController _playerController;

    public override void InstallBindings()
    {
        if (_gameSettings.IsTutorialCompleted) 
        {
            PlayerControllerMain playerControllerMain = new(_camera, _player);
            playerControllerMain.Init(_playerMovementSpeed);
            _playerController = playerControllerMain;
            Container.BindInterfacesTo<PlayerControllerMain>().FromInstance(_playerController);
            Container.Bind<PlayerController>().To<PlayerControllerMain>().FromInstance(playerControllerMain);
        }            
        else
        {
            PlayerControllerTutorial playerControllerTutorial = new(_camera, _player);
            playerControllerTutorial.Init(_playerMovementSpeed);
            _playerController = playerControllerTutorial;
            Container.BindInterfacesTo<PlayerControllerTutorial>().FromInstance(_playerController);
            Container.Bind<PlayerController>().To<PlayerControllerTutorial>().FromInstance(playerControllerTutorial);
        }
        
        Container.Bind<CheckPlayerControllerInstaller>().FromNew().AsSingle().NonLazy();
    }

    public override void Start()
    {
        _gameEvents = Container.Resolve<GameEvents>();
        if(_gameEvents == null)
        {
            Debug.Log("signal bus is null");
        }
        Container.Resolve<PlayerController>().SubscribeEvents(_gameEvents);

        _gameEvents.controllerChangeInDependencyContainer.OnPlayerControllerRebindCalled += ChangeControllerToMain;
    }

    public void OnDestroy()
    {
        _gameEvents.controllerChangeInDependencyContainer.OnPlayerControllerRebindCalled -= ChangeControllerToMain;
    }

    public void ChangeControllerToMain()
    {
        PlayerControllerMain playerControllerMain = new(_camera, _player);
        playerControllerMain.Init(_playerMovementSpeed);
        _playerController = playerControllerMain;
        Container.BindInterfacesAndSelfTo<PlayerControllerMain>().FromInstance(playerControllerMain);
        Container.Rebind<PlayerController>().FromInstance(_playerController);
        Container.Resolve<PlayerController>().SubscribeEvents(_gameEvents);
        _gameEvents.controllerChangeInDependencyContainer.OnPlayerControllerRebinded?.Invoke(Container.Resolve<PlayerController>());
    }
}
