using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    [SerializeField] private float xMax = 143.5f;
    [SerializeField] private float xMin = 0f;
    [SerializeField] private float yMax = 0f;
    [SerializeField] private float yMin = 0f;
    [SerializeField] private Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;

        if (player.position.x > xMin)
        {
            if (player.position.x < xMax) 
            temp.x = player.position.x;
            else temp.x = xMax;
        }
        else
        {
            temp.x = xMin;
        }

        if (player.position.y > yMin)
        {
            if (player.position.y < yMax)
                temp.y = player.position.y;
            else temp.y = yMax;
        }
        else
        {
            temp.y = yMin;
        }

        transform.position = temp;
    }
}
