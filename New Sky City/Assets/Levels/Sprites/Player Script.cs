using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D body;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2(moveInput, body.velocity.y);
    }
}
