using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public GameObject currentWeapon;

    public void SwitchWeapon(GameObject newWeapon)
    {
        // Disable the current weapon
        currentWeapon.SetActive(false);

        // Enable the new weapon
        newWeapon.SetActive(true);

        // Update the reference to the current weapon
        currentWeapon = newWeapon;
    }
}
