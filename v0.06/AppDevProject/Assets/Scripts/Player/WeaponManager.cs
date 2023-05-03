using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    [Header("Firebase")]
    public GameObject Magic;
    public GameObject Sword;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    void Start()
    {
        Unequip();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipMagic();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            EquipSword();
        }
    }

    public void Unequip()
    {
        Magic.SetActive(false);
        Sword.SetActive(false);
    }

    public void EquipMagic()
    {
        Unequip();
        Magic.SetActive(true);
    }

    public void EquipSword()
    {
        Unequip();
        Sword.SetActive(true);
    }
}
