using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private DIContainer _container;

    private void Awake()
    {
        _container = new DIContainer();

        _container.RegisterAsSingle(CreateConfigsProviderService);
    }

    private ConfigsProviderService CreateConfigsProviderService(DIContainer container)
    {
        ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

        ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(resourcesAssetsLoader);

        return new ConfigsProviderService(resourcesConfigsLoader);
    }

    private ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer container)
    {
        return new ResourcesAssetsLoader();
    }
}
