using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem part;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(other);
        }
           
    }
}
