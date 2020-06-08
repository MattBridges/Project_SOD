using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTargeting : MonoBehaviour
{


    public static GameObject FindClosestTarget<T>(List<T> possibleTargets, Transform originShip) where T : Component
    {
        GameObject closestTarget = null;

        foreach (T target in possibleTargets)
        {
            if (closestTarget != null)
            {
                float curClosestDist = Vector2.Distance(closestTarget.transform.position, originShip.position);
                if (IzzyUtilities.RangeToTarget(originShip.gameObject, target.gameObject)<curClosestDist)
                {
                    closestTarget = target.gameObject;
                }
            }
            else
            {
                closestTarget = target.gameObject;
            }

        }


        return closestTarget;
    }
}
