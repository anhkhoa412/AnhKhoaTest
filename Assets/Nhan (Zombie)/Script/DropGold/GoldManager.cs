using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public GameObject goldPrefab;
    public void DropGold(int minAmount, int maxAmount, Vector3 positionDrop)
    {
        int goldAmount = Random.Range(minAmount, maxAmount + 1);
        //Quantity gold is drop by zombie

        for (int i = 0; i < goldAmount; i++)
        {
            Vector3 goldPosition = positionDrop + new Vector3(Random.Range(-1f, 1f), 0.5f, Random.Range(-1f, 1f));
            GameObject gold = Instantiate(goldPrefab, goldPosition, Quaternion.identity);
            if (gold != null )
            {
                Destroy(gold, 0.5f);
            }
        }
    }
}
