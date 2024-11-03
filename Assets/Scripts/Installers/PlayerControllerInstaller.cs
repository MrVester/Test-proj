using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerControllerInstaller : MonoInstaller
{
    bool isTutorial = true;
    public override void InstallBindings()
    {
        if (isTutorial)
            Container.Bind<IPlayerController>().To<PlayerControllerTutorial>().FromComponentInHierarchy().AsSingle();
        else
            Container.Bind<IPlayerController>().To<PlayerControllerMain>().FromNew().AsSingle();
      Container.Bind<CheckPlayerControllerInstaller>().FromNew().AsSingle().NonLazy();
    }
}
