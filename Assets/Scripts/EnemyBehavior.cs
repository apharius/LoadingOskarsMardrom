using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    private GameObject player;
    private GameStateHandler handler;
    private Rigidbody2D body;
    private int hitCount;
    public float speed;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        hitCount = 0;
        body = GetComponent<Rigidbody2D>();
        handler = GameObject.Find("GameStateHandler").GetComponent<GameStateHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = Vector2.MoveTowards(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), new Vector2(player.transform.position.x, player.transform.position.y), speed * Time.deltaTime);
        this.transform.position = direction;
	}

    public void TakeDamage()
    {
        hitCount++;
        

        if (hitCount > 1)
        {
            handler.score += 10;
            handler.newKill();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Player" && player.GetComponent<PlayerBehavior>().alive)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }


}
