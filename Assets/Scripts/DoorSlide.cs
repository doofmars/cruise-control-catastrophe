using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlide : MonoBehaviour
{
    private bool openDoor = false;
    private bool closeDoor = false;
    private float doorOpened = 0;
    private float maxDoorMove = 0.5f;
    private float minDoorMove = 0;
    private float keepPosition = 0;
    public bool doorLockRequest = false;
    private bool doorLocked = false;

    private Transform top;
    private Transform bottom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float passedTime = Time.deltaTime;
        float moveBy = passedTime * 1;
        Vector3 movingVector = new Vector3(0.0f, 0.0f, 0.0f);
        if (keepPosition == 0.0f && openDoor && doorOpened < maxDoorMove)
        {
            //openingDoor
            doorOpened += moveBy;
            movingVector = new Vector3(0.0f, moveBy,0.0f);
        }
        if (keepPosition == 0.0f && closeDoor && doorOpened >= minDoorMove)
        {
            //closing Door
            doorOpened -= moveBy;
            movingVector = new Vector3(0, -moveBy, 0);
        }
        if (keepPosition > 0.0f)
        {
            keepPosition -= passedTime;

            if (keepPosition <= 0.0f)
            {
                keepPosition = 0.0f;
                closeDoor = true;
            }
        }
        if (doorOpened > maxDoorMove)
        {
            movingVector = new Vector3(0, moveBy - (doorOpened - maxDoorMove), 0);
            doorOpened = maxDoorMove;
            openDoor = false;
            keepPosition = 3;
        }
        if (doorOpened < minDoorMove)
        {
            movingVector = new Vector3(0, -(moveBy - (doorOpened - minDoorMove)), 0);
            doorOpened = minDoorMove;
            closeDoor = false;
            keepPosition = 0;
        }
        //Unlock door
        if(doorLockRequest && doorLocked)
        {
            doorLockRequest = false;
            doorLocked = false;
        }
        //Lock door
        if (doorLockRequest && doorOpened == 0.0f)
        {
            doorLockRequest = false;
            doorLocked = true;
        }
        movingVector = transform.rotation * movingVector;
        foreach (Transform child in transform)
        {
            if (child.name == "Bottom")
            {
                movingVector *= -1;
            }
            Vector3 currentPosition = child.position + movingVector;
            child.position = currentPosition;
        }

    }

    public void setOpenDoor()
    {
        if (!doorLocked && doorOpened == 0.0f)
        {
            openDoor = true;
            keepPosition = 0;
        }
    }

}
