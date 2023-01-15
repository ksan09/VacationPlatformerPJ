using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody2D _boxRb;

    private void Awake()
    {
        _boxRb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.transform.CompareTag("Ground"))
        {
            _boxRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (col.transform.CompareTag("Ground"))
        {
            _boxRb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Ground"))
        {
            _boxRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
