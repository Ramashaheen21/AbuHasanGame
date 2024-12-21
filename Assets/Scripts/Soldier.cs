using UnityEngine;

public class Soldier : MonoBehaviour
{
     public Sprite flatSprite;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("AbuHasan") )
        {
            Abuhasan abuhasan = collision.gameObject.GetComponent<Abuhasan>();

            if (collision.transform.DotTest(transform, Vector2.down)) {
                Flatten();
            }
            else {
                abuhasan.Hit();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shell")) {
            Hit();
        }
    }

     private void Flatten()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<EnemyMovement>().enabled = false;
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = flatSprite;
        Destroy(gameObject, 0.5f);
    }


    private void Hit()
    {
        GetComponent<AnimatedSprite>().enabled = false;
        GetComponent<DeathAnimation>().enabled = true;
        Destroy(gameObject, 3f);
    }

}

