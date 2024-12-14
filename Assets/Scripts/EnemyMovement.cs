using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   private new Rigidbody2D rigidbody;
   private Vector2 velocity;

   public float speed = 2f;
   public Vector2 direction = Vector2.left;
   


   private void Awake()
   {
        rigidbody = GetComponent<Rigidbody2D>();
        enabled = false;
   }
   private void OnBecameInvisible()
   {
        enabled = true;
   }

   private void OnEnable()
   {
        rigidbody.WakeUp();
   }

   private void OnDisable()
   {
        rigidbody.velocity = Vector2.zero;
        rigidbody.Sleep();
   }

   private void FixedUpdate()
   {
        velocity.x = direction.x + speed;
        velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);

        if(rigidbody.Raycast(direction)){
            direction = -direction;
        }

        if(rigidbody.Raycast(Vector2.down)){
            velocity.y = Mathf.Max(velocity.y , 0f);
        }
   }
}
