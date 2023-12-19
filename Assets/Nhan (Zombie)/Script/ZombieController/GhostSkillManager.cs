using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class GhostSkillManager : LinesSpawn
{
    float moveSpeed = 5f;

    public float totalTime = 0f;
    public void BlinkToPosition()
    {
        int index = Random.Range(0, positionLines.Count);
        float posZ = positionLines[index];
        Vector3 endPosition = new Vector3(transform.position.x, transform.position.y, posZ);
         float pingPongTime = Mathf.PingPong(Time.deltaTime * moveSpeed, 1f);
         Vector3 newPosition = Vector3.Lerp(transform.position,endPosition , pingPongTime);
        transform.position = newPosition;

        //total time zombie is Invincibling
        totalTime += Time.deltaTime;

    }
}
