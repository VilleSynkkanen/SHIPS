using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperCannonShooter : CannonShooter
{
    [SerializeField] Transform[] rotationPoints;
    [SerializeField] float[] originalRotations;
    [SerializeField] float[] rotationGoals;
    
    float[] shotRotations;

    private new void Start()
    {
        base.Start();
        shotRotations = new float[rotationPoints.Length];
    }

    public override void ResetState()
    {
        base.ResetState();
        for (int i = 0; i < rotationPoints.Length; i++)
        {
            rotationPoints[i].localEulerAngles = new Vector3(0, 0, originalRotations[i]);
        }
    }
    
    public override void Shoot()
    {
        for (int i = 0; i < rotationPoints.Length; i++)
            shotRotations[i] = rotationPoints[i].localEulerAngles.z;
        StartCoroutine(Shot(chargeMatters: false));
    }

    public override void ShotInput(bool input)
    {
        base.ShotInput(input);
        for(int i = 0; i < rotationPoints.Length; i++)
        {
            if(input && cooldownLeft <= 0)
            {
                Vector3 rotation = new Vector3(0, 0, Mathf.LerpAngle(originalRotations[i], rotationGoals[i], shotCharge));
                rotationPoints[i].localEulerAngles = rotation;
            }
            else if(!input && cooldownLeft > 0)
            {
                Vector3 rotation = new Vector3(0, 0, Mathf.LerpAngle(originalRotations[i], shotRotations[i], cooldownLeft / Data.ShotCooldown));
                rotationPoints[i].localEulerAngles = rotation;
            }
        }
    }
}
