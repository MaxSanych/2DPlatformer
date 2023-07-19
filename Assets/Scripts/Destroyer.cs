using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gem>(out Gem gem))
        {
            Destroy(collision.gameObject);
        }
    }
}
