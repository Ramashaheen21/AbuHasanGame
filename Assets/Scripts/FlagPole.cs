using System.Collections;
using UnityEngine;

public class FlagPole : MonoBehaviour
{
public Transform flag;
    public Transform poleTop;
    public Transform castle;
    public float speed = 6f;
    public int nextWorld = 1;
    public int nextStage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Abuhasan player))
        {
            StartCoroutine(MoveTo(flag, poleTop.position));
            StartCoroutine(LevelCompleteSequence(player));
        }
    }

    private IEnumerator LevelCompleteSequence(Abuhasan player)
    {
        player.movement.enabled = false;

        yield return MoveTo(player.transform, poleTop.position);
        yield return MoveTo(player.transform, player.transform.position + Vector3.right);
        yield return MoveTo(player.transform, player.transform.position + Vector3.right + Vector3.down);
        yield return MoveTo(player.transform, castle.position);

        player.gameObject.SetActive(false);

        //yield return new WaitForSeconds(2f);

        //GameManager.Instance.LoadLevel(nextWorld, nextStage);
    }

    private IEnumerator MoveTo(Transform subject, Vector3 destination)
    {
        while (Vector3.Distance(subject.position, destination) > 0.125f)
        {
            subject.position = Vector3.MoveTowards(subject.position, destination, speed * Time.deltaTime);
            yield return null;
        }

        subject.position = destination;
    }


}
