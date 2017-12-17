using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public float speed;
    private Rigidbody2D body;
    private Camera mainCamera;
    public Hammer hammer;
    public int health;
    private GameStateHandler gameState;
    public Sprite deathSprite;
    public bool alive;
    

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        gameState = GameObject.Find("GameStateHandler").GetComponent<GameStateHandler>();
        alive = true;
	}

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Hammer newHammer = Instantiate(hammer, this.transform.position, this.transform.rotation);
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), newHammer.GetComponent<Collider2D>());
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector3 throwDirection = (Input.mousePosition - screenPoint).normalized;
            newHammer.body.AddForce(throwDirection * 600);

        }
    }

    // Update is called once per frame
    void FixedUpdate () {
        mainCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalMovement, verticalMovement);
        body.velocity = (movement * speed);

       
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Enemy")
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();

            if(health > 0)
            {
                health -= 10;
            }
           

            if (health <= 0) {
                health = 0;
                alive = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = deathSprite;
                audioSource.mute = true;
                this.enabled = false;
                gameState.GameOver();
            }

        }
    }
}
