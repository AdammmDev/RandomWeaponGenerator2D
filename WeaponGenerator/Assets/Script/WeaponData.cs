using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    Mythic,
    Exotic
}

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/New Weapon")]
public class WeaponData: ScriptableObject
{
    // Define properties for the weapon
    public Sprite[] sprites;
    public WeaponRarity rarity;
    public int damage;
    public float critChance;
    public float critMultiplier;


}

