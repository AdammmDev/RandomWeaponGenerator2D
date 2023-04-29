using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponGenerator : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;

    [Space(10)]

    [Header("RarityChance")]
    [SerializeField, Range(0f, 100f)] private float commonChance = 90f;
    [SerializeField, Range(0f, 100f)] private float uncommonChance = 30f;
    [SerializeField, Range(0f, 100f)] private float rareChance = 14f;
    [SerializeField, Range(0f, 100f)] private float epicChance = 5f;
    [SerializeField, Range(0f, 100f)] private float legendaryChance = 1f;
    [SerializeField, Range(0f, 100f)] private float mythicChance = 0.01f;
    [SerializeField, Range(0f, 100f)] private float exoticChance = 0.001f;
    [Header("Elementes")]
    [SerializeField] private Image weaponImage;
    [SerializeField] private TMP_Text statsText;

    [Space(10)]
    [SerializeField] private Slider commonSlider, uncommonSlider, rareSlider, epicSlider, legendarySlider, mythicSlider, exoticSlider;


    public void UpdateValues()
    {
        commonChance = commonSlider.value;
        uncommonChance = uncommonSlider.value;
        rareChance = rareSlider.value;
        epicChance = epicSlider.value;
        legendaryChance = legendarySlider.value;
        mythicChance = mythicSlider.value;
        exoticChance = exoticSlider.value;

    }

    private void Start()
    {
        //Generating weapon at the start
        GenerateWeaponButton();
    }

    // Method to generate a random rarity for the weapon
    private void GenerateRandomRarity()
    {
        //Self explanatory
        float randomRarity = Random.Range(0f, 100f);

        if (randomRarity < commonChance)
        {
            weaponData.rarity = WeaponRarity.Common;
        }
        else if (randomRarity < commonChance + uncommonChance)
        {
            weaponData.rarity = WeaponRarity.Uncommon;
        }
        else if (randomRarity < commonChance + uncommonChance + rareChance)
        {
            weaponData.rarity = WeaponRarity.Rare;
        }
        else if (randomRarity < commonChance + uncommonChance + rareChance + epicChance)
        {
            weaponData.rarity = WeaponRarity.Epic;
        }
        else if (randomRarity < commonChance + uncommonChance + rareChance + epicChance + legendaryChance)
        {
            weaponData.rarity = WeaponRarity.Legendary;
        }
        else if (randomRarity < commonChance + uncommonChance + rareChance + epicChance + legendaryChance + mythicChance)
        {
            weaponData.rarity = WeaponRarity.Mythic;
        }
        else if (randomRarity < commonChance + uncommonChance + rareChance + epicChance + legendaryChance + mythicChance + exoticChance)
        {
            weaponData.rarity = WeaponRarity.Exotic;
        }
    }


    private void GenerateRandomStats(WeaponData weapon)
    {
        //After getting random rarity then generating random stats for rarity type

        //Good idea to make level system and changing rarityChance drop higher if player has high level
        switch (weapon.rarity)
        {
            case WeaponRarity.Common:
                weapon.damage = Random.Range(1, 5);
                weapon.critChance = Random.Range(2, 6);
                weapon.critMultiplier = Random.Range(1.01f, 1.2f);
                break;
            case WeaponRarity.Uncommon:
                weapon.damage = Random.Range(3, 67);
                weapon.critChance = Random.Range(4, 13);
                weapon.critMultiplier = Random.Range(1.03f, 1.43f);
                break;
            case WeaponRarity.Rare:
                weapon.damage = Random.Range(10, 243);
                weapon.critChance = Random.Range(6, 18);
                weapon.critMultiplier = Random.Range(1.05f, 2f);
                break;
            case WeaponRarity.Epic:
                weapon.damage = Random.Range(23, 684);
                weapon.critChance = Random.Range(8, 23);
                weapon.critMultiplier = Random.Range(1.08f, 2.5f);
                break;
            case WeaponRarity.Legendary:
                weapon.damage = Random.Range(67, 2999);
                weapon.critChance = Random.Range(10, 28);
                weapon.critMultiplier = Random.Range(1.2f, 4.65f);
                break;
            case WeaponRarity.Mythic:
                weapon.damage = Random.Range(2134, 2999);
                weapon.critChance = Random.Range(13, 34);
                weapon.critMultiplier = Random.Range(1.3f, 8.6f);
                break;
            case WeaponRarity.Exotic:
                weapon.damage = Random.Range(34324, 324324324);
                weapon.critChance = Random.Range(163, 40);
                weapon.critMultiplier = Random.Range(2.5f, 34.5f);
                break;
        }
    }

    private WeaponData GenerateRandomWeapon()
    {
        //If WeaponData has nothing assigned then what are we looking for? ERORR
        if(weaponData==null)
        {
            Debug.LogError("I dont have WeaponData to generate from");
            return null;
        }
        //If weaponData is not null then get Random Rarity
        //Instantiate randomWeaponData
        //Generating stats for the weapon
        //Getting random sprite from weaponData
        
        GenerateRandomRarity();
        WeaponData newWeapon = Instantiate(weaponData);
        GenerateRandomStats(newWeapon);
        weaponImage.sprite = newWeapon.sprites[Random.Range(0,newWeapon.sprites.Length)];
        weaponImage.SetNativeSize();
        return newWeapon;
    }


    public void GenerateWeaponButton()
    {
        //If player Click on the button the generate weapon and displaying text.
        WeaponData newWeapon = GenerateRandomWeapon();

        // TODO: Display the newWeapon sprite and stats as desired
        Debug.Log($"Generated a {newWeapon.rarity} weapon with {newWeapon.damage} damage, {newWeapon.critChance} crit chance, and {newWeapon.critMultiplier} multiplier.");

        if(newWeapon != null)
            statsText.text = $"Rarity: {newWeapon.rarity} | Damage: {newWeapon.damage} | CritChance: {newWeapon.critChance} | CritMultiplier {newWeapon.critMultiplier.ToString("F2")}";
    }
}

