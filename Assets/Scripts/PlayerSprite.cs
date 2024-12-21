using UnityEngine;

public class PlayerSprite : MonoBehaviour
{
   private PlayerMovement movement;
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite idle;
    public Sprite jump;
    public AnimatedSprite run;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
        
    }
    
    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
        //run.enabled = false;
    }

    private void LateUpdate()
    {
        //run.enabled = movement.running;

        if (movement.jumping) {
            spriteRenderer.sprite = jump;
        } else if (!movement.running) {
            spriteRenderer.sprite = idle;
        }
    }

    

}
