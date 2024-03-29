﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;

    public GameObject projectile;
    public Transform shotPoint;

    public float shotTime;
    public float startShotTime;

    // Update is called once per frame
    private void Update()
    {
        //take mouse position - transform position to get x and y values of difference.
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //do tan y/x * rad2Deg to find angle of rotaiton
        float RotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, RotationZ + offset);

        if (shotTime <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                shotTime = startShotTime;
            }
        }
        else
        {
            shotTime -= Time.deltaTime;
        }
        
    }
}
