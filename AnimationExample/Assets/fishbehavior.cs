using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishbehavior : MonoBehaviour
{
    public float moveSpeed = 0.004f;
    // Use this for initialization

    GameObject currentFood = null;
    private float startTime;
    private float journeyLength;

    public float turnDuration = 2;
    private Vector3 startingAngle;
    private Vector3 targetAngle;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (currentFood == null)
        {
            currentFood = GameObject.Find("fishfood");
            if (currentFood != null)
            {
                //init move info for a new target
                startTime = Time.time;
                journeyLength = Vector3.Distance(transform.position, currentFood.transform.position);

                //init rotation info for a new target
                Vector3 vectorToTarget = ((currentFood.transform.position) - transform.position).normalized;
                float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x); //this will be in radians
                startingAngle = transform.localEulerAngles;
                targetAngle = new Vector3(0, 0, angleToTarget * Mathf.Rad2Deg - 45);
            }
        }
        if(currentFood != null)
        {
            //transform.position = Vector2.Lerp(transform.position, currentFood.transform.position, moveSpeed);

            //Vector3 difference = currentFood.transform.position - transform.position;
            //difference.Normalize();
            //float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);

            //Lerp position
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, currentFood.transform.position, fracJourney);

            //      float damping = 0.1f;
            //      var lookPos = currentFood.transform.position - transform.position;
            //      lookPos.x = 0;
            //      lookPos.y = 0;
            //      var rotation = Quaternion.LookRotation(lookPos);
            //      transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

            //Lerp rotation
            float rotationCovered = (Time.time - startTime) ;
            float interpolated = rotationCovered / turnDuration;
            transform.localEulerAngles = Vector3.Lerp(startingAngle, targetAngle, interpolated);

            /** Working snap rotation code
            Vector3 vectorToTarget = ((currentFood.transform.position) - transform.position).normalized;
            float angleToTarget = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x); //this will be in radians
            transform.localEulerAngles = new Vector3(0, 0, angleToTarget * Mathf.Rad2Deg - 45); //might need some offset like 90 depending on your sprite```
            */


        }
        checkIfFishEatFood();

     //   Vector3 mousePos = Input.mousePosition;
     //   mousePos.z = 10;
     //   Vector3 mouseInWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        //   transform.position = Vector2.Lerp(transform.position, mouseInWorldPos, moveSpeed);

        //   Vector3 difference = mouseInWorldPos - transform.position;
        //   difference.Normalize();
        //   float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //   transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
    }

    void checkIfFishEatFood()
    {
        if (currentFood != null)
        {
            if (Vector3.Distance(transform.position, currentFood.transform.position) < 0.5f)
            {
                GameObject.Destroy(currentFood);
                currentFood = null;
            }
        }
    }
}


