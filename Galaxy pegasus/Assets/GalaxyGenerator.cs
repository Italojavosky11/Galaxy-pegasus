
using UnityEngine;

public class GalaxyGenerator : MonoBehaviour
{
    public ParticleSystem particleSystem;

    public int quantidade = 5000;
    public int bracos = 4;
    public float raio = 10f;
    public float abertura = 0.5f;
    public float espessura = 0.3f;

    void Start()
    {
        GerarGalaxia();
    }

    void GerarGalaxia()
    {
        ParticleSystem.Particle[] particulas =
            new ParticleSystem.Particle[quantidade];

        for (int i = 0; i < quantidade; i++)
        {
            float distancia = Random.Range(0f, raio);

            int braco = i % bracos;

            float angulo =
                braco * Mathf.PI * 2f / bracos
                + distancia * abertura
                + Random.Range(-0.3f, 0.3f);

            Vector3 posicao = new Vector3(
                Mathf.Cos(angulo) * distancia,
                Random.Range(-espessura, espessura),
                Mathf.Sin(angulo) * distancia
            );

            particulas[i].position = posicao;
            particulas[i].startSize = Random.Range(0.03f, 0.1f);
            particulas[i].startColor = Color.Lerp(
                new Color(0.3f, 0.4f, 1f),
                Color.white,
                Random.value
            );
            particulas[i].remainingLifetime = 1000f;
        }

        particleSystem.SetParticles(particulas, quantidade);
    }
}
