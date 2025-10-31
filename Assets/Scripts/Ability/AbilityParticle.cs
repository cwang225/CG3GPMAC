using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/30/25
 * Date Last Updated: 10/30/25
 * Summary: A particle to animate an effect, with an offset as needed
 */
public class AbilityParticle : MonoBehaviour
{
    public GameObject particlePrefab;
    //public Vector3 offset;
    [HideInInspector] public float animationTime;

    private void Awake()
    {
        animationTime = particlePrefab.GetComponent<ParticleSystem>().main.duration;
    }

    public void Play(Tile target)
    {
        Instantiate(particlePrefab, target.transform);
    }
}
