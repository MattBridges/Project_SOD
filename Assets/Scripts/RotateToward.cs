using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToward : MonoBehaviour
{
    public Tile target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GetComponent<Enemy>().target;
        if (target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            float fixedAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotateAngle = Quaternion.AngleAxis(fixedAngle-90, Vector3.forward);
            transform.rotation = rotateAngle;
        }
        
    }
}
