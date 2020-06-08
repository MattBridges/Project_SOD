using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer rend;
    public Color damagedColor;
    public Sprite mainTile;
    public Sprite[] flavorTileSprites;
    public int randomizerWeight;
    public float hoverAmount;
    public LayerMask buildableLayer;
    public GameObject laser;
    private PlayerStationManager station;
    public ShopManager shop;
    public GameObject tilesTurret;
    public AudioClip placeTurretSound;
    public AudioClip tileDestroyedSound;
    public bool hasTurret;

    private SoundManager sm;

    public int health;
    public int healthTreshold;



    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        sm = FindObjectOfType<SoundManager>();
        station = FindObjectOfType<PlayerStationManager>();
        shop = FindObjectOfType<ShopManager>();
        station.AddTile(this);
        hasTurret = false;
        BuildShip();
    }
    private void OnMouseEnter()
    {
        transform.localScale += Vector3.one * hoverAmount;
    }
    private void OnMouseExit()
    {
        transform.localScale -= Vector3.one * hoverAmount;
    }
    private void OnMouseDown()
    {
        if (IsBuildable())
        {
            //PlaceObject(laser);
            if (shop.selectedItem != null)
            {
                PlaceObject(shop.selectedItem.gameObject);
                shop.CompletePurchase(shop.selectedItem);
            }
            
            
        }
        else { Debug.Log("Not Buildable"); }
    }

    private void BuildShip()
    {
        
        rend.sprite = TileType();
    }

    private Sprite TileType()
    {
        int randomizer = Random.Range(0, 100);

        if(randomizer <= randomizerWeight)
        {
            int randTile = Random.Range(0, flavorTileSprites.Length);
            return flavorTileSprites[randTile];
        }
        else
        {
            return mainTile;
        }
    }

    private bool IsBuildable()
    {
        //Collider2D buildable = Physics2D.OverlapCircle(transform.position, .3f, buildableLayer);
        //if (buildable)
        //{
        //    return true;
        //}
        //else
        //{
        //    return false;
        //}
        return true;
        
    }

    public void PlaceObject(GameObject item)
    {
        if(item.name == "Heal Item")
        {
            RepairDamage(shop.healAmount);
        }
        else
        {
            sm.OneShot(placeTurretSound);
            tilesTurret = Instantiate(item, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            hasTurret = true;
        }
        
        
    }

    public void TakeDamage(int amt)
    {
        health -= amt;
        if(health <= healthTreshold)
        {
            rend.color = damagedColor;
        }

        if (health <= 0)
        {
            DestroyTile();
        }
    }

    public void RepairDamage(int amt)
    {
        health += amt;
        if (health <= healthTreshold)
        {
            rend.color = damagedColor;
        }
        else
        {
            rend.color = Color.white;
        }

    }

    public void DestroyTile()
    {
        sm.OneShot(tileDestroyedSound);
        station.stationTiles.Remove(this);
        Destroy(this.gameObject);
        Destroy(tilesTurret);
    } 

}
