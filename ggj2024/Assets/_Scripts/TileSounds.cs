using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[System.Serializable]
public struct TileCategory
{
    public string Category;
    public Tile[] tiles;
}
public class TileSounds : MonoBehaviour
{
    [SerializeField] private TileCategory[] tileCategories;
    [SerializeField] private string defaultCategory = "GrassDefault";
    private PlayerMovement playerMovement;
    private Tilemap tilemap;
    private Vector3Int location;
    private Transform playerTransform;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerMovement = playerTransform.GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetTileSound", .1f, .2f);
    }

    private void SetTileSound()
    {
        playerMovement.SetStepSounds(GetTileCategory());
     //   print(GetTileCategoty());
    }

    private string GetTileCategory()
    {
        var currentTile = GetCurrentTile();

        string category = string.Empty;

        foreach (var tileCategory in tileCategories) 
        {
            foreach (var tile in tileCategory.tiles)
            {
                if (tile==currentTile)
                {
                    category = tileCategory.Category;
                }
            }
        }

        if (category == string.Empty)
        {
            return defaultCategory;
        }
        else
        {
            return category;
        }
    }

    private Tile GetCurrentTile()
    {
        location = tilemap.WorldToCell(playerTransform.position);

        return tilemap.GetTile<Tile>(location);
    }
}
