using UnityEngine;

public class ParticleUnparenter : MonoBehaviour
{
    [SerializeField] bool stopOnDestruction;
    [SerializeField] ParticleSystem system;

    public void ProjectileDestruction()
    {
        if (stopOnDestruction)
            system.Stop();
        system.transform.SetProjectileParent();
        Destroy(system.gameObject, 15);
    }
}
