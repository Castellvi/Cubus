using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameManager manager;

	public float moveSpeed;
	public GameObject deathParticles;

	private float maxSpeed = 5f;
	private Vector3 input;
	private Vector3 spawn;
	// Use this for initialization
	void Start () {
		spawn = transform.position;
		manager = manager.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		input = new Vector3(Input.GetAxisRaw("Horizontal"),0f, Input.GetAxisRaw("Vertical"));

		if (Input.GetAxisRaw ("Horizontal") != 0 || Input.GetAxisRaw ("Vertical") != 0) {
			if (Input.GetAxisRaw ("Horizontal") == 0) {
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
			}
			else if (Input.GetAxisRaw ("Vertical") == 0) {
				rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ;
			}
			else {
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
			}
		} else {
			rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		}

//		if (Input.GetAxisRaw ("Vertical") == 0) {
//			//print ("No vertical");
//			//rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
//			rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX;
//		}


		//print(rigidbody.constraints.ToString);
		if (rigidbody.velocity.magnitude < maxSpeed) {
			rigidbody.AddRelativeForce(input*moveSpeed);
		}
		if (transform.position.y < -2) {
			Die();
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.tag == "Enemy") {
			Die();
		}
		if (other.transform.tag == "Paret") {
			input = new Vector3(-Input.GetAxisRaw("Horizontal"),0f, -Input.GetAxisRaw("Vertical"));
			rigidbody.AddRelativeForce(input*moveSpeed*2);
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "Goal") {
			manager.CompleteLevel();
		}
		if (other.transform.tag == "Enemy") {
			Die();
		}
		
		if (other.transform.tag == "Token") {
			manager.tokenCount++;
			Destroy(other.gameObject);
		}
	}

	void Die() {
		Instantiate (deathParticles, transform.position, Quaternion.Euler(270,0,0));
		transform.position = spawn;
	}

}
