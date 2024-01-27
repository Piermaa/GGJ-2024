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
    [SerializeField] private float checkTime = .1f;
    private PlayerMovement playerMovement;
    private Tilemap tilemap;
    private Vector3Int location;
   [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();

        playerMovement = playerTransform.GetComponent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetTileSound", checkTime, .2f);
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
