using System;
using System.Collections;

public class GameplayBootstrap : SceneBootstrap
{
    private DIContainer _container;
    private GameplayInputArgs _inputArgs;

    public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
    {
        _container = container;

        if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
            throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

        _inputArgs = gameplayInputArgs;

        GameplayContextRegistrations.Process(_container, _inputArgs);
    }

    public override IEnumerator Initialize()
    {
        yield break;
    }

    public override void Run()
    {
    }
}
