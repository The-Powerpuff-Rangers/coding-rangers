using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement3 : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private double timeleft = 10;



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

        if (GameObject.FindGameObjectWithTag("L1").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("A").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("B").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("E").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("L2").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

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

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "LL1" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("L1").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "AA" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("A").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "BB" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("B").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "EE" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("E").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "LL2" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("L2").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }

    }


}