using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class OneHandedMelee : ScriptableObject
{
    public Animator weaponHolder;

    public bool moonblade;
    public bool mace;

    public int moonBladeDMG;
    public int maceDMG;

    public bool attacking;
}
