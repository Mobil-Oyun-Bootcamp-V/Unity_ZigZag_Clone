using UnityEngine;

public class Particle : MonoBehaviour
{
    private ParticleSystem _particalSystem;
    void Awake()
    {
        _particalSystem = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!_particalSystem.isPlaying)
            Destroy(gameObject);
    }
}
