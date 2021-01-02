using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{   
    private bool canAttack = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null)
        {
            if (canAttack == true)
            {
                hit.Damage();
                canAttack = false;
                StartCoroutine(ResetAttackRoutine());
            }
            
        }
    }

    IEnumerator ResetAttackRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
