using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class DrWeaponTemplate : ScriptableObject
{
    public Animator animation;

    public int DMG;

    public bool attacking;
}
