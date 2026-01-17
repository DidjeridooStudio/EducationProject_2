using UnityEngine;

public class ResourcesAssetsLoader : MonoBehaviour
{
    public T Load<T>(string resourcePath) where T : Object => Resources.Load<T>(resourcePath);
}
