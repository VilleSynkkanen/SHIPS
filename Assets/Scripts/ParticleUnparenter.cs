using UnityEngine;

public class ParticleUnparenter : MonoBehaviour
{
    [SerializeField] ParticleSystem system;

    public void ProjectileDestruction()
    {
        //system.Stop();
        system.transform.SetProjectileParent();
        Destroy(system.gameObject, 15);
    }
}
