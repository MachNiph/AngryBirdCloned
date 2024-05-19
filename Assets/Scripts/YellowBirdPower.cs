using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBirdPower : BirdPower
{
    protected override void PowerUp()
    {
        Vector3 distance = transform.position - birdPosition;
        Vector3 dir = distance.normalized;
        rb.AddForce(dir * forcePower, ForceMode2D.Impulse);
    }
}
