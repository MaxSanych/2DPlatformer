using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Gem>(out Gem gem))
        {
            Destroy(collision.gameObject);
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
