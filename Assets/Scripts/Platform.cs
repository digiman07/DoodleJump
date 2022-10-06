using UnityEngine;
public class Platform : MonoBehaviour {

	public float jumpForce = 0f;
	public AudioClip Bounce;

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log(this.name);
		if (collision.relativeVelocity.y <= 0f)
		{
			AudioSource audio = GetComponent<AudioSource>();
			audio.clip = Bounce;
			audio.Play();

			if (this.tag == "BrokenPlatform")
			{
				//Debug.Log(this.tag);
				transform.GetChild(0).gameObject.SetActive(false);
				transform.GetChild(1).gameObject.SetActive(true);
				transform.GetChild(2).gameObject.SetActive(true);
				this.GetComponent<EdgeCollider2D>().enabled = false;
			}

            if (this.tag == "Spring")
            {
                //Debug.Log(this.tag);
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
                this.GetComponent<EdgeCollider2D>().enabled = false;
            }

            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}
		}
	}

}
