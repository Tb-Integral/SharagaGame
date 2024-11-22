using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;

        if (player.position.x > 0)
        {
            if (player.position.x < 143.5f) 
            temp.x = player.position.x;
            else temp.x = 143.5f;
        }
        else
        {
            temp.x = 0;
        }

        temp.y = 0f;

        transform.position = temp;
    }
}
