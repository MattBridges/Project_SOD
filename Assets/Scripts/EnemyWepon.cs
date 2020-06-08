using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWepon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPos;
    public float shotDelay;
    public float range;


    private float shotTimer;
    private PlayerStationManager station;
    private Tile closest;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        station = FindObjectOfType<PlayerStationManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (ClosestEnemy() != null)
        {
            target = ClosestEnemy().transform;
            float distToTarget = Vector2.Distance(target.position, transform.position);
            Vector2 direction = target.position - transform.position;
            float fixedAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotateAngle = Quaternion.AngleAxis(fixedAngle, Vector3.forward);
            transform.rotation = rotateAngle;
        }


        if (target != null && RangeToTarget(target.GetComponent<Tile>()) <= range)
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        if (Time.time >= shotTimer)
        {
            Instantiate(projectile, shotPos.position, transform.rotation);
            shotTimer = Time.time + shotDelay;
        }
    }

    private bool EnemyInRange()
    {
        foreach (Tile tile in station.stationTiles)
        {
            float dist = Vector2.Distance(tile.transform.position, transform.position);
            Debug.Log("Distance To Enemy = " + dist);
            if (dist <= range)
            {
                return true;
            }
        }
        return false;
    }
    private float RangeToTarget(Tile tar)
    {
        if (tar != null)
            return Vector2.Distance(tar.transform.position, transform.position);
        else
            return 100;
    }
    private Tile ClosestEnemy()
    {

        foreach (Tile tile in station.stationTiles)
        {
            if (closest != null)
            {
                float curClosestDist = Vector2.Distance(closest.transform.position, transform.position);
                if (RangeToTarget(tile) < curClosestDist)
                {
                    closest = tile;
                }
            }
            else
            {
                closest = tile;
            }

        }
        return closest;
    }
}
