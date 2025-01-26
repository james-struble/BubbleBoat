using System;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem part;
    public EventHandler OnEnemyHit;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        OnEnemyHit?.Invoke(this, EventArgs.Empty);
        if(other.tag == "Enemy")
        {
            Destroy(other);
        }
    }
}
