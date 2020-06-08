using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IzzyUtilities : MonoBehaviour
{
    public static float RangeToTarget(GameObject source, GameObject target)
    {
        if (target != null)
            return Vector2.Distance(target.transform.position, source.transform.position);
        else
            return 100;
    }
}
