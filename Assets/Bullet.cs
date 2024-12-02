using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifetime = 30f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
}
