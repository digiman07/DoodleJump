using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour 
{
	public float movementSpeed = 10f;
	private SpriteRenderer _renderer;
	Rigidbody2D rb;

	float movement = 0f;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();

		_renderer = GetComponent<SpriteRenderer>();
		if (_renderer == null)
		{
			Debug.LogError("Player Sprite is missing a renderer");
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		movement = Input.GetAxis("Horizontal") * movementSpeed;

		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			_renderer.flipX = false;
		}
		else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			_renderer.flipX = true;
		}
	}

	void FixedUpdate()
	{
		Vector2 velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;
	}
}
