using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool open = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerInRange)
            {
                // does the player have a key?
                //if yes Open()
            }
        }
    }

    public void Open()
    {
        //turn of sprite renderer
        // set open to true
        //turn off box collider
    }

    public void Closed()
    {

    }
}
