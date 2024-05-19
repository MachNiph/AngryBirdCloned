using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBirdPower : BirdPower
{
    public GameObject birdPrefab;
    public float offsetDistance = 1.0f;


    protected override void PowerUp()
    {

        Vector3 distance = transform.position - birdPosition;
        Vector3 dir = distance.normalized;


        Vector3 upPosition = transform.position + Vector3.up * offsetDistance;
        Vector3 downPosition = transform.position + Vector3.down * offsetDistance;

        GameObject upBird = Instantiate(birdPrefab, transform.position, Quaternion.identity);
        GameObject downBird = Instantiate(birdPrefab, transform.position, Quaternion.identity);

        upBird.GetComponent<BirdPower>().enabled = false;
        downBird.GetComponent<BirdPower>().enabled = false;


        rb.velocity *= forcePower;
        upBird.GetComponent<Rigidbody2D>().velocity = rb.velocity + Vector2.up * 5;
        downBird.GetComponent<Rigidbody2D>().velocity = rb.velocity - Vector2.up * 5;

        


    }
}
