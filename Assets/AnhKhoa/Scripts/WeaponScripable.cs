using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeapomScriptable", menuName = "Weapons")]
public class Weapon: ScriptableObject
{
    [SerializeField]
    private int id;
    [SerializeField]
    private string nameGun;
    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private float[] damage;
    [SerializeField]
    private float rateOfFire;
    [SerializeField]
    private int amminition;
    [SerializeField]
    private float reloadSpeed;
    [SerializeField]
    private int maxDistance;
    [SerializeField]
    public float currentAmmor;
    public bool reloading;
    [SerializeField]
    public Sprite Sprite { get => sprite; set => sprite = value; }
    public float[] Damage { get => damage; set => damage = value; }
    public float RateOfFire { get => rateOfFire; set => rateOfFire = value; }
    public float ReloadSpeed { get => reloadSpeed; set => reloadSpeed = value; }
    public int MaxDistance { get => maxDistance; set => maxDistance = value; }
    public int Amminition { get => amminition; set => amminition = value; }
    public int Id { get => id; set => id = value; }
    public string NameGun { get => nameGun; set => nameGun = value; }
}


