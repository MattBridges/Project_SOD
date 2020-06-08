using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField]
    private float offsetFromTarget;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotateAngleCorrection;

    public void MoveTowardTarget(GameObject target)
    {
        if (IzzyUtilities.RangeToTarget(this.gameObject,target) > offsetFromTarget)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    public void RotateTowardTarget(GameObject target)
    {
        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float fixedAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotateAngle = Quaternion.AngleAxis(fixedAngle - rotateAngleCorrection, Vector3.forward);
            transform.rotation = rotateAngle;
        }
    }
}
