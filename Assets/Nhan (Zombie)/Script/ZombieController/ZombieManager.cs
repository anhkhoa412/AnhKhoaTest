using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : LinesSpawn
{
    [SerializeField] float timeWaitSpawn;

    public GameObject prefabGhost;
    public GameObject prefabBasic;
    public GameObject prefabConehead;
    public GameObject prefabBuckethead;
    public GameObject prefabFootball;
    public GameObject prefabDog;

    private void Awake()
    {
        InvokeRepeating("SpawnEffect", 1f, timeWaitSpawn);
    }
    public void SpawnEffect()
    {
        int index = Random.Range(0, positionLines.Count);
        float posZ = positionLines[index];
        Vector3 spawnPosition = new Vector3(transform.position.x, 0f, posZ);

        int[] listZombie = { 1, 2, 3, 4, 5, 6 };
        int indexs = Random.Range(0, listZombie.Length);
        int typeZombie = listZombie[indexs];
        
        switch (typeZombie)
        {
            case 1:
                SpawnTypeZombie(prefabDog, spawnPosition);
                break;
            case 2: 
                SpawnTypeZombie(prefabBasic,spawnPosition);
                break;
            case 3:
                SpawnTypeZombie(prefabConehead,spawnPosition);
                break;
            case 4:
                SpawnTypeZombie(prefabBuckethead,spawnPosition);
                break;
            case 5:
                SpawnTypeZombie(prefabFootball,spawnPosition);
                break;
            default:
                SpawnTypeZombie(prefabGhost, spawnPosition);
                break;
        }
    }

    public void SpawnTypeZombie(GameObject prefab,Vector3 positionSpawn)
    {
        Quaternion quaternion = prefab.transform.rotation;

       GameObject zombie =  Instantiate(prefab, positionSpawn, quaternion);
        zombie.SetActive(true);
    }


}
