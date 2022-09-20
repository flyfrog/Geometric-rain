using UI;
using UnityEngine;
using Zenject;

public class MonoInstaler : MonoInstaller
{
    [SerializeField] private SOSpawnSettings _soSpawnSettings;
    [SerializeField] private SOPlayerShapeSettings _soPlayerShapeSettings;
    [SerializeField] private SOPoolSettings _soPoolSettings;
    [SerializeField] private SOSoundSettings _soSoundSettings;
    [SerializeField] private SOFXSettings _sofxSettings;

    public override void InstallBindings()
    {
        //Scriptable object
        Container.Bind<SOSpawnSettings>().FromInstance(_soSpawnSettings).AsSingle().NonLazy();
        Container.Bind<SOPlayerShapeSettings>().FromInstance(_soPlayerShapeSettings).AsSingle().NonLazy();
        Container.Bind<SOPoolSettings>().FromInstance(_soPoolSettings).AsSingle().NonLazy();
        Container.Bind<SOSoundSettings>().FromInstance(_soSoundSettings).AsSingle().NonLazy();
        Container.Bind<SOFXSettings>().FromInstance(_sofxSettings).AsSingle().NonLazy();


        //NORMAL class
        Container.Bind<PauseController>().AsSingle().NonLazy();
        Container.Bind<PlayerHitController>().AsSingle().NonLazy();
        Container.Bind<GameOverController>().AsSingle().NonLazy();
        Container.Bind<ScoreController>().AsSingle().NonLazy();
        Container.Bind<RestartController>().AsSingle().NonLazy();
        Container.Bind<UIStartMenuController>().AsSingle().NonLazy();
        Container.Bind<PlayerDeathFXController>().AsSingle().NonLazy();
        Container.Bind<PlayerDeathController>().AsSingle().NonLazy();
        Container.Bind<SpawnerAddScoreFX>().AsSingle().NonLazy();
        Container.Bind<FallShapeAddScoreHider>().AsSingle().NonLazy();
        Container.Bind<PusherController>().AsSingle().NonLazy();
        Container.Bind<ColorSetterFallShapeController>().AsSingle().NonLazy();
        Container.Bind<RandomKindSetterController>().AsSingle().NonLazy();
        Container.Bind<SetterStartPositionService>().AsSingle().NonLazy();
       


        //INTARFACE realize
        Container.BindInterfacesAndSelfTo<SpawnerFallShapesController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<PlayerMoveController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<InputManager>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<StartGameController>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<ScoreTextAnmator>().AsSingle().NonLazy();
    }
}