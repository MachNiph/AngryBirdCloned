using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private ParticleSystem enemyDeathSmoke;
    [SerializeField] private float destroyVelocity;
    [SerializeField] private Sprite[] enemyHitSprites;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(TagManager.Bird) || collision.gameObject.CompareTag(TagManager.Wood))
        {
            if (collision.transform.GetComponent<Rigidbody2D>().velocity.magnitude > destroyVelocity)
            {
                health--;

                if (health >= 0 && health < enemyHitSprites.Length)
                {
                    spriteRenderer.sprite = enemyHitSprites[health];
                }

                if (health < 0)
                {
                    Instantiate(enemyDeathSmoke, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }

        if (collision.gameObject.CompareTag(TagManager.Ground) || collision.gameObject.CompareTag(TagManager.Bird) || collision.gameObject.CompareTag(TagManager.Wood) || collision.gameObject.CompareTag(TagManager.Enemy))
        {
            if (rb.velocity.magnitude > destroyVelocity)
            {
                health--;

                if (health >= 0 && health < enemyHitSprites.Length)
                {
                    spriteRenderer.sprite = enemyHitSprites[health];
                }

                if (health < 0)
                {
                    Instantiate(enemyDeathSmoke, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                }
            }
        }
    }

}
