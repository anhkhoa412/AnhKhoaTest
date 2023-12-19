using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieLayer
{
    Ghost,
    Basic,
    Conehead,
    Buckethead,
    Football,
    Dog
}

public class DropGold : GoldManager
{
    public ZombieLayer zombieLayer;
    void OnDestroy()
    {
        if (gameObject != null)
        {
            if (gameObject.layer == LayerMask.NameToLayer(zombieLayer.ToString()))
            {
                switch (zombieLayer)
                {
                    case ZombieLayer.Ghost:
                        if (gameObject != null)
                        { DropGold(36, 40, transform.position); }
                        break;

                    case ZombieLayer.Basic:
                        if (gameObject != null)
                        { DropGold(20, 25, transform.position); }
                        break;

                    case ZombieLayer.Conehead:
                        if (gameObject != null)
                        { DropGold(26, 30, transform.position); }
                        break;

                    case ZombieLayer.Buckethead:
                        if (gameObject != null)
                        { DropGold(31, 35, transform.position); }
                        break;

                    case ZombieLayer.Football:
                        if (gameObject != null)
                        { DropGold(36, 40, transform.position); }
                        break;

                    case ZombieLayer.Dog:
                        if (gameObject != null)
                        { DropGold(21, 25, transform.position); }
                        break;
                }
            }
        }
    }
}