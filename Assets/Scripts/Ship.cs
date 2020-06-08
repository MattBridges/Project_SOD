using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMovement))]
public class Ship : MonoBehaviour
{
    public GameObject target;
    private ShipMovement shipMover;
    private List<Tile> stationTiles;
    // Start is called before the first frame update
    void Start()
    {
        shipMover = GetComponent<ShipMovement>();
        stationTiles = FindObjectOfType<PlayerStationManager>().stationTiles;
        target = ShipTargeting.FindClosestTarget(stationTiles, this.transform);
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            target = ShipTargeting.FindClosestTarget(stationTiles, this.transform);
        }
        shipMover.MoveTowardTarget(target);
        shipMover.RotateTowardTarget(target);
    }
}

