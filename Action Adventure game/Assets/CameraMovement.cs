using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform player;
    public float camSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != player.position)
        {
            Vector3 playerPosition = new Vector3 (player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, playerPosition, camSpeed);
        }
    }
}
