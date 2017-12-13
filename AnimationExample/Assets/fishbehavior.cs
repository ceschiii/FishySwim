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
                startTime = Time.time;
                journeyLength = Vector3.Distance(transform.position, currentFood.transform.position);
            }
        }
        if(currentFood != null)
        {
            //transform.position = Vector2.Lerp(transform.position, currentFood.transform.position, moveSpeed);

            //Vector3 difference = currentFood.transform.position - transform.position;
            //difference.Normalize();
            //float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);


            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(transform.position, currentFood.transform.position, fracJourney);

            //      float damping = 0.1f;
            //      var lookPos = currentFood.transform.position - transform.position;
            //      lookPos.x = 0;
            //      lookPos.y = 0;
            //      var rotation = Quaternion.LookRotation(lookPos);
            //      transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);

            Vector3 targetPostition = new Vector3(currentFood.transform.position.z,
                                     0,
                                     0);
            this.transform.LookAt(targetPostition);



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


