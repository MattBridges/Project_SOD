using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wepon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPos;
    public float shotDelay;
    public float range;
    public AudioClip shotSound;


    private float shotTimer;
    private EnemyManager enemyManager;
    private Enemy closest;
    private Transform target;
    private SoundManager sm;

    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        sm = FindObjectOfType<SoundManager>();
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

 
        if (target != null && RangeToTarget(target.GetComponent<Enemy>()) <= range)
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
            sm.OneShot(shotSound);
        }
    }

    private bool EnemyInRange()
    {
        foreach (Enemy enemy in enemyManager.enemies)
        {
            float dist = Vector2.Distance(enemy.transform.position, transform.position);
            Debug.Log("Distance To Enemy = " + dist);
            if (dist <= range)
            {
                return true;
            }
        }
        return false;
    }
    private float RangeToTarget(Enemy tar)
    {
        return Vector2.Distance(tar.transform.position, transform.position);
    }
    private Enemy ClosestEnemy()
    {

        foreach (Enemy enemy in enemyManager.enemies)
        {
            if (closest != null)
            {
                float curClosestDist = Vector2.Distance(closest.transform.position, transform.position);
                if (RangeToTarget(enemy) < curClosestDist)
                {
                    closest = enemy;
                }
            }
            else
            {
                closest = enemy;
            }

        }
        return closest;
    }

}









