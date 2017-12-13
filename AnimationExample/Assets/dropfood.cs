using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropfood : MonoBehaviour {

    public GameObject foodPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            Vector3 mouseInWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            mouseInWorldPos.z = 0;
            GameObject food = (GameObject)Instantiate(foodPrefab, mouseInWorldPos, transform.rotation);
            food.name = "fishfood";
        }
    }
	}


