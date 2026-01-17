using System.Collections;

public class MainMenuBootstrap : SceneBootstrap
{
    private DIContainer _container;

    public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
    {
        _container = container;

        MainMenuContextRegistrations.Process(_container);
    }

    public override IEnumerator Initialize()
    {
        yield break;
    }

    public override void Run()
    {
    }
}
