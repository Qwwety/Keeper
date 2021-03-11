using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private bool LookLeft=true;

    public void LookForPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1;

        if(transform.position.x>=Player.position.x && !LookLeft)
        {
            Flip();
        }
        else if (transform.position.x <= Player.position.x && LookLeft)
        {
            Flip();
        }
    } 

    private void Flip()
    {
        Vector3 Transformer = transform.localScale;
        Transformer.x *= -1;
        transform.localScale = Transformer;
        LookLeft = !LookLeft;
    }
}
