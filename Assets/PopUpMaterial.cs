using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpMaterial : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI monsterBloodText;
    [SerializeField] TextMeshProUGUI arcaneSandText;
    [SerializeField] TextMeshProUGUI theoriteText;

    [SerializeField] PlayerStats playerStats;
    [SerializeField] EnemyCS enemyCS;

    public void Awake()
    {
        monsterBloodText.text = enemyCS.monsterBloodGain.ToString();
        arcaneSandText.text = enemyCS.arcaneSandGain.ToString();
        theoriteText.text = enemyCS.theoriteGain.ToString();

        playerStats.redMaterials += enemyCS.monsterBloodGain;
        playerStats.yellowMaterials += enemyCS.arcaneSandGain;
        playerStats.purpleMaterials += enemyCS.theoriteGain;
    }
}
