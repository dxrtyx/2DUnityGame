using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBox : MonoBehaviour
{
    public float damage = 0.5f;
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerscript player = hitInfo.GetComponent<playerscript>();
        if (player) {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
