using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;
    [SerializeField] TextMeshProUGUI damageText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI movementSpeedText;
    [SerializeField] TextMeshProUGUI attackSpeedText;

    private void Start()
    {
        UpdatePlayerUIStats();
    }

    public void UpdatePlayerUIStats()
    {
        damageText.text = playerStats.damage.ToString();
        healthText.text = playerStats.health.ToString();
        movementSpeedText.text = playerStats.movementSpeed.ToString();
        attackSpeedText.text = playerStats.attackSpeed.ToString();
    }

    public void modifiedStat(Item item)
    {
        
    }
}
