using UnityEngine;
using Zenject;

public class SceneControllerInstaller : MonoInstaller
{
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private float _duration;
    [SerializeField] private string _gameplaySceneName;
 
    public override void InstallBindings()
    {
       _sceneController = new SceneController(_duration, _gameplaySceneName);
       Container.Bind<SceneController>().FromInstance(_sceneController);
    }

    public override void Start()
    {
        _sceneController.Init();
    }
}
