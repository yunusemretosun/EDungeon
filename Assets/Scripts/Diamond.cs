using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{



    public int gems = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerManager player = other.GetComponent<PlayerManager>();
           
            if (player != null)
            {
                player.diamonds += gems;
                Destroy(this.gameObject,0.3f);
            }
           
        }
    }



}
