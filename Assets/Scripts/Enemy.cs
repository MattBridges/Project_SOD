using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float stopOffset;
    public float speed;
    public Tile target;
    public int killValue;
    public GmManager gm;
    private SoundManager sm;
    public ParticleSystem explosionEffect;

    public AudioClip explosionSound;

    private PlayerStationManager station;
    

    private void Start()
    {
        station = FindObjectOfType<PlayerStationManager>();
        gm = FindObjectOfType<GmManager>();
        sm = FindObjectOfType<SoundManager>();
       
    }

    private void Update()
    {
        if(target !=null)
        {
            MoveTowardTarget();
        }
        else
        {
            FindATarget();
        }
        
    }


    public void DamageShip(int amount)
    {
        health -= amount;
        if (health <= 0)
            DestroyShip();
    }

    void DestroyShip()
    {
        gm.AddCredits(killValue);
        gm.IncreaseScore(killValue);
        sm.OneShot(explosionSound);
        //explosionEffect.Play();
        Instantiate(explosionEffect, new Vector2(transform.position.x,transform.position.y),Quaternion.identity);
        Destroy(this.gameObject);
    }
    private float RangeToTarget(Tile tar)
    {
        if (tar != null)
            return Vector2.Distance(tar.transform.position, transform.position);
        else
            return 100;
    }



    void MoveTowardTarget()
    {
        if (RangeToTarget(target) > stopOffset)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }



    Tile FindATarget()
    {
        
        foreach (Tile tile in station.stationTiles)
        {
            if (target != null)
            {
                float curClosestDist = Vector2.Distance(target.transform.position, transform.position);
                if (RangeToTarget(tile) < curClosestDist)
                {
                    target = tile;
                }
            }
            else
            {
                target = tile;
            }

        }
        return target;
    }

   
}
