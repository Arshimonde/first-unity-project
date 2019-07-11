using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    public int speed;
    public SpriteRenderer spriteRenderer;
    public Animator anim;
    public float jumpForce;
    public Rigidbody2D rig;
    public bool isGrounded;
    public Transform bulletLeftPosition;
    public Transform bulletRightPosition;
    public GameObject Bullet;
    public float shotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        anim.SetBool("isShooting", false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(rig.velocity.y < 0)
        {
            rig.velocity += Vector2.up * Physics2D.gravity.y * 2  * Time.deltaTime;
        }
    }

    //Movement
    public void Movement()
    {

        //Shooting
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isShooting", true);
            if (spriteRenderer.flipX)
            {
                GameObject newBullet = Instantiate(Bullet, bulletRightPosition.position,transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * shotSpeed;
            }
            else
            {
                GameObject newBullet = Instantiate(Bullet, bulletLeftPosition.position, transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * -shotSpeed;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isShooting", false);
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rig.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            anim.SetBool("isGrounded", false);
            anim.SetBool("isShooting", false);
        }
        //Move left & right
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = true;
            anim.SetBool("isShooting", false);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            spriteRenderer.flipX = false;
            anim.SetBool("isShooting", false);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    //On Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            anim.SetBool("isGrounded", true);
        }
    }
}
