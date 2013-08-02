using System.IO;
using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerControls : MonoBehaviour 
{
    public float MovementSpeed = 2.0f;
    public float Gravity = 20.0f;
    public Vector3 Velocity;

    private Transform cachedTransform;
    private CharacterController characterController;

	// Use this for initialization
    private	void Start() 
    {
        cachedTransform = gameObject.transform;
        characterController = this.GetComponent<CharacterController>();
	}

	// Update is called once per frame
    private void Update() 
    {
        if (characterController.isGrounded)
        {
            Velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }

        Velocity.x *= MovementSpeed;

        Velocity.y -= Gravity * Time.fixedDeltaTime;
        characterController.Move(Velocity * Time.fixedDeltaTime);
	}
}
