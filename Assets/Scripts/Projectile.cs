using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public int damageAmt;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy"  && this.tag == "Projectile")
        {
            collision.GetComponent<Enemy>().DamageShip(damageAmt);
            DestroyProjectile();
        }
        if (collision.tag == "Station Tile" && this.tag == "Enemy Projectile")
        {
            collision.GetComponent<Tile>().TakeDamage(damageAmt);
            DestroyProjectile();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right  * speed * Time.deltaTime);
    }

   private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
