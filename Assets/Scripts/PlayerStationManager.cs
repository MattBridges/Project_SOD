using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStationManager : MonoBehaviour
{
    public List<Tile> stationTiles;

    private GmManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GmManager>();
    }
    private void Update()
    {
        if(stationTiles.Count <= 0)
        {
            gm.GameOver();
        }
    }

    public void RemoveTile(Tile tile)
    {
        stationTiles.Remove(tile);
    }

    public void AddTile(Tile tile)
    {
        stationTiles.Add(tile);
    }

 
}
