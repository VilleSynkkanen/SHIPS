using UnityEngine;

public class ParticleUnparenter : MonoBehaviour
{
    [SerializeField] bool stopOnDestruction;
    [SerializeField] bool destroyAndSetParentOnDestruction;
    [SerializeField] ParticleSystem system;

    public void ProjectileDestruction()
    {
        if (stopOnDestruction)
            system.Stop();
        if(destroyAndSetParentOnDestruction)
        {
            system.transform.SetProjectileParent();
            Destroy(system.gameObject, 15);
        }
    }
}
