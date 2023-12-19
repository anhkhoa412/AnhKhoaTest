using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerAction : MonoBehaviour
{

    public static Action shootInput;
    public static Action reloadInput;
    public static Action sowInput;
    public EItemType type;
    [SerializeField] private Animator anim;
   

    void Start()
    {
      
       // anim = GetComponent<Animator>();
    }

    public void Shoot()
    {
        shootInput?.Invoke();
        anim.SetTrigger("Shooting");
    }

    public void Reload()
    {
        reloadInput?.Invoke();
    }

    public void Sow()
    {
        if (FindObjectOfType<PlayerInventory>().mCurrentItem.ItemType == EItemType.Tower )
        {
            sowInput?.Invoke();
        }
    }
    }
