using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    //представим что здесь есть или когда-нибудь будет какая-то логика
    private void OnTriggerEnter(Collider other)
    {
        bool isThisBall = other.TryGetComponent<Ball>(out Ball ball);

        if (isThisBall)
            gameObject.SetActive(false);
    }
}
