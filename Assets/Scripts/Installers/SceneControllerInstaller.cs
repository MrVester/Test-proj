using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
       Container.Bind<SceneController>().FromResource("SceneController").AsSingle().NonLazy();
    }

}
