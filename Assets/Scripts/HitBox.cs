using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float destroyVelocity;
    [SerializeField] private BirdDirection birdDirection;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(rb.velocity.magnitude > destroyVelocity)
        {
            if (collision.gameObject.CompareTag(TagManager.Enemy))
            {
                Destroy(collision.gameObject);
            }
            if (birdDirection!=null && (collision.gameObject.CompareTag(TagManager.Enemy) || collision.gameObject.CompareTag(TagManager.Wood)))
            {
                birdDirection.isFlying = false;
            }
        }

       
       
    }
}
