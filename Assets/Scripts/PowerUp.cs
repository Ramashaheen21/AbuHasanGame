using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum Type
    {
        pinkflower,
        redflower,
        rockFlower,
        kaak,
        Falafel,
    }

    public Type type;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("AbuHasan")){
            collect(other.gameObject);
        }
    }

    private void collect(GameObject abuhasan)
    {
        switch(type)
        {
            case Type.pinkflower:
                GameManager.Instance.AddCoin();
              break;
            
            case Type.redflower:
                GameManager.Instance.AddLife();

              break;

            case Type.rockFlower:
            
              break;

            case Type.Falafel:
            
              break;

            case Type.kaak:
            
              break;

        }
        Destroy(gameObject);
    }
}
