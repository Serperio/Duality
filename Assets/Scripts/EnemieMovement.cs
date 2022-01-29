using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{
    public int director;
    public int speed;
    public EyeController eye; //Si =1, aparece con ojo derecho abierto, si=0, con el ojo izquierdo, cuando estan ambos abiertos no afecta 
    Vector2 initPos;
    public int initdir;
    Rigidbody2D rigidbody2D;
    Collider2D collider;
    SpriteRenderer spriteRenderer;
    bool respawn;


    void Start()
    {
        respawn = true;
        initPos = transform.position;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (eye.IsClosed)
        {
            collider.enabled = false;
            spriteRenderer.enabled = false;
            respawn = true;

        }
        else if(respawn)
        {
            director = initdir;
            speed = Mathf.Abs(speed);
            collider.enabled = true;
            transform.position = initPos;
            spriteRenderer.enabled = true;
            respawn = false;
        }
        speed = speed * director;
        rigidbody2D.velocity = new Vector2(speed * Time.fixedDeltaTime, rigidbody2D.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ChangeDir")
        {
            director = director * -1;
        }
        if (collision.gameObject.tag == "Player")
        {
            print("moristes :c");
        }
    }
}
