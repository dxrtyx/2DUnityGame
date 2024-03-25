using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBox : MonoBehaviour
{
    public float damage = 1f;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerscript player = hitInfo.GetComponent<playerscript>();
        if (player) {
            player.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
