using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool horizontalCollision;



    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //Flip player when facing left/right.
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        Vector3 newRotation = new Vector3(0, 0, 0);
        transform.eulerAngles = newRotation;

        //sets animation parameters
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tile" || collision.gameObject.tag == "lift")
            grounded = true;

        // if(collision.gameObject.tag == "tile")

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "FF" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("F").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "OO" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("O").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "RR" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("R").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "MM" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("M").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }

    }


}