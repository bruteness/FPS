using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity;

    private CharacterController _controller;
    private Vector3 _velocity;
    private bool _groundedPlayer;
    private float _jumpHeight = 1.0f;

    void Start() {
        _controller = GetComponent<CharacterController>();
    }

    void Update() {
        //Handle the movement for the player
        Movement();

        if (Input.GetButton("Jump") && _groundedPlayer) //Predefined jump in unity mapped to the space bar
        {
            Jump();
        }

        _velocity.y += _gravity * Time.deltaTime; //Setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); //Movement based on velocity
    }

    private void Movement() {
        _groundedPlayer = _controller.isGrounded; //Was the character touching the ground during the last frame? Accessing character controller's isGrounded property

        if (_groundedPlayer && _velocity.y < 0) {
            _velocity.y = 0f; //If the character was grounded in the last frame and is now moving in a negative velocity (falling down), set the velocity (speed and direction) to zero
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //Predefined axes in Unity linked to WASD controllers
        move = transform.TransformDirection(move);

        _controller.Move(move * Time.deltaTime * _moveSpeed); //Moves character in the given direction from our move vector3

        _velocity.y += _gravity * Time.deltaTime; //Setting velocity in the y direction to the acceleration of gravity in relation to our fps (Time.deltaTime)
        _controller.Move(_velocity * Time.deltaTime); //Movement based on velocity

    }

    private void Jump() {
        _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity); //Change velocity to represent a jumping behavior
    }
}