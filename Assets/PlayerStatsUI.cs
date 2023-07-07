using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] PlayerStats playerStats;

    [SerializeField] PlayerStatsInfo damageInfo;
    [SerializeField] PlayerStatsInfo healthInfo;
    [SerializeField] PlayerStatsInfo movementSpeedInfo;
    [SerializeField] PlayerStatsInfo attackSpeedInfo;

    public static Action<Item> CraftingItemSelected;
    public static Action CraftingItemUnSelected;

    private void Start()
    {
        UpdatePlayerUIStats();
    }

    public void UpdatePlayerUIStats()
    {
        Debug.Log("Update Player UI Stats");

        damageInfo.setText(playerStats.damage, 0);
        healthInfo.setText(playerStats.health, 0);
        movementSpeedInfo.setText(playerStats.movementSpeed, 0);
        attackSpeedInfo.setText(playerStats.attackSpeed, 0);
    }

    public void ModifiedStat(Item item)
    {
        Debug.Log("Update MODIFIED Player UI Stats");

        damageInfo.setText(playerStats.damage, item.damageModifier);
        healthInfo.setText(playerStats.health, item.healthModifier);
        movementSpeedInfo.setText(playerStats.movementSpeed, item.movementSpeedModifier);
        attackSpeedInfo.setText(playerStats.attackSpeed, item.attackSpeedModifier);
    }

    public void OnEnable()
    {
        CraftingItemSelected += ModifiedStat;
        CraftingItemUnSelected += UpdatePlayerUIStats;
    }
    public void OnDisable()
    {
        CraftingItemSelected -= ModifiedStat;
        CraftingItemUnSelected -= UpdatePlayerUIStats;
    }
}
