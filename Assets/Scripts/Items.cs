using System.Collections;
using UnityEngine;

public class Items : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator Animate()
    {

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        rigidbody.isKinematic = true;
        circle.enabled = false;
        box.enabled = false;
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.25f);
 spriteRenderer.enabled = true;

        float elapsed = 0f;
        float duration = 0.5f;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = transform.position + Vector3.up;

        while (elapsed < duration)
        {
            float t = elapsed / duration;

            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            elapsed += Time.deltaTime;

            yield return null;
        }

        rigidbody.isKinematic = false;
        circle.enabled = true;
        box.enabled = true;
    }



}
