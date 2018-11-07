using UnityEngine;
using System.Collections;

public class ParticlesAttractor : MonoBehaviour {
    [SerializeField]
    ParticleSystem ps;
    ParticleSystem.Particle[] parts;
    Vector2[] posofparts;
    Vector2 endp;
    float t;
    int z;
    void Start()
    {
        parts = new ParticleSystem.Particle[ps.particleCount];
        z = ps.GetParticles(parts);
        posofparts = new Vector2[ps.particleCount];
        for (int i = 0;i< posofparts.Length;i++)
        {
            posofparts[i] = parts[i].position;
        }
        endp = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        //t = 1f - Mathf.Cos(t * Mathf.PI * 0.5f);
        
        t += Time.deltaTime;

        for (int i = 0; i < posofparts.Length; i++)
        {
            
            parts[i].position = Vector2.Lerp(posofparts[i], endp, t);
        }
        ps.SetParticles(parts,z);

    }
    
}
