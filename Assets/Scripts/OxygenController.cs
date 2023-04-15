using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class OxygenController : MonoBehaviour
{
    [SerializeField] private Slider oxygenSlider;
    [SerializeField] private Tilemap waterTilemap;
    [SerializeField] private float maxOxygen = 100f;
    [SerializeField] private float oxygenDecreaseRate = 8f;
    [SerializeField] private float oxygenIncreaseRate = 25f;
    [SerializeField] private Text oxygenPercentageText;

    private float currentOxygen;

    private void Start()
    {
        currentOxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
    }

    public player player;
    private void Update()
    {
        if (IsUnderwater())
        {
            currentOxygen -= oxygenDecreaseRate * Time.deltaTime;
        }
        else
        {
            currentOxygen += oxygenIncreaseRate * Time.deltaTime;
        }

        currentOxygen = Mathf.Clamp(currentOxygen, 0f, maxOxygen);

        oxygenSlider.value = currentOxygen;

        // Update the oxygen percentage text
        float oxygenPercentage = currentOxygen / maxOxygen * 100f;
        oxygenPercentageText.text = oxygenPercentage.ToString("F0") + "%";



        if (currentOxygen <= 0f)
        {
            player.hitpoint -= 1;
        }
    }

    private bool IsUnderwater()
    {
        // Get the position of the player
        Vector3Int position = waterTilemap.WorldToCell(transform.position);

        // Check if there is a tile at the player's position
        TileBase tile = waterTilemap.GetTile(position);
        bool isUnderwater = tile != null;
        return isUnderwater;
    }
}