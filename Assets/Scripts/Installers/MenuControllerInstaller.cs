using UnityEngine;
using Zenject;

public class MenuControllerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MenuController>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}