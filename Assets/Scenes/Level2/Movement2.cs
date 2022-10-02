using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement2 : MonoBehaviour
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

        if (GameObject.FindGameObjectWithTag("I").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("N").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("P").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("U").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled && GameObject.FindGameObjectWithTag("T").GetComponent<TMPro.TextMeshProUGUI>().isActiveAndEnabled)
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
        if (collision.gameObject.tag == "II" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("I").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "NN" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("N").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "PP" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("P").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "UU" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("U").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }
        else if (collision.gameObject.tag == "TT" && Input.GetKey(KeyCode.Space))
        {
            GameObject.FindGameObjectWithTag("T").GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        }

    }


}