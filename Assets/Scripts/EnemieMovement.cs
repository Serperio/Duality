using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieMovement : MonoBehaviour
{

    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
    [SerializeField] private int director;
    [SerializeField] private int speed;
    [SerializeField] private EyeController eye; //Si =1, aparece con ojo derecho abierto, si=0, con el ojo izquierdo, cuando estan ambos abiertos no afecta 
    [SerializeField] private Vector2 initPos;
    [SerializeField] private int initdir;
    private Rigidbody2D rb;
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    private bool respawn;

    

    void Start()
    {
        respawn = true;
        initPos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
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
       

        if(transform.position.x < leftWall.position.x || transform.position.x > rightWall.position.x)
        {
            
            director *= -1;
        }
        speed = speed * director;
        
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            print("moristes :c");
        }
    }
}
