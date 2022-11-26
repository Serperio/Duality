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

    private bool canChange = true;
    private float canChangeCounter = 0;
    private float initPos;
    private int initDir;
    private float leftPos;
    private float rightPos;



    private Rigidbody2D rb;
    private Collider2D collider;
    private SpriteRenderer sr;
    private bool respawn;

    

    void Start()
    {
        respawn = true;
        initDir = director;
        initPos = transform.localPosition.x;
        leftPos = leftWall.transform.TransformPoint(Vector3.zero).x;
        rightPos = rightWall.transform.TransformPoint(Vector3.zero).x;
        rb = gameObject.GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(eye != null)
        {
            if (eye.IsClosed)
            {
                collider.enabled = false;
                sr.enabled = false;
                respawn = true;

            }
            else if (respawn)
            {
                //director = initDir;
                //speed = Mathf.Abs(speed);
                collider.enabled = true;
                //transform.position = new Vector3(initPos, transform.position.y, transform.position.z);
                sr.enabled = true;
                respawn = false;
            }
        }
        




        if (transform.position.x < leftPos)
        {
            print("menor");
            director = 1;
        }

        if (transform.position.x > rightPos)
        {
            print("mayor");
            director = -1;
        }

        if (rb.velocity.x > 0) sr.flipX = true;
        else sr.flipX = false;
        speed = Mathf.Abs(speed) * director;
        if (respawn) rb.velocity = new Vector2(0 * Time.fixedDeltaTime, rb.velocity.y);
        else rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ChangeDir")
        {
            director *= -1;
        }
        if (collision.gameObject.tag == "Player")
        {
            print("moristes :c");
            LevelManager.instance.ResetLevel();
        }
    }
}
