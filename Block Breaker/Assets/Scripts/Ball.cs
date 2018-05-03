using UnityEngine;

public class Ball : MonoBehaviour

{
    private Paddle paddle;

    private Vector3 paddleToBallVector;

    private bool hasStarted = false;

    //public Rigidbody2D rb = new Rigidbody2D();

  
    // Use this for initialization
    void Start ()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
	    paddleToBallVector = this.transform.position - paddle.transform.position;
        

    }
	
	// Update is called once per frame
	void Update ()
	{
        Begin();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));

        if (hasStarted)
        {
            GetComponent<Rigidbody2D>().velocity += tweak;
            //dodavanje zvuka pri udarcu
            //AudioSource audio = GetComponent<AudioSource>();
            //audio.Play();
        }
    }

    void Begin()
    {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(Random.Range(-2f, 2f), 10f);
            }
        }
    }


}
