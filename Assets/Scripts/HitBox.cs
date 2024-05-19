using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BirdDirection birdDirection;


    [SerializeField] private ParticleSystem woodDestroy;

   
 
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (birdDirection != null && (collision.gameObject.CompareTag(TagManager.Enemy) || collision.gameObject.CompareTag(TagManager.Wood)))
        {
            birdDirection.isFlying = false;
        }

        if(collision.gameObject.CompareTag(TagManager.Wood) && rb.velocity.magnitude > 0.4)
        {
            Destroy(collision.gameObject);
            Instantiate(woodDestroy,collision.gameObject.transform.position,Quaternion.identity);
        }
       
    }
}
