using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour {

	[SerializeField] private Transform target;
	private CharacterController _charController;
	private float _vertSpeed;
	private ControllerColliderHit _contact;
	private Animator _animator;
	
	public float rotSpeed = 15.0f;
	public float moveSpeed = 12.0f;
	public float jump_Speed = 20.0f;
	public float gravity = -9.8f;
	public float terminalVelocity = -30.0f;
	public float minFall = -9.8f;
	
	public float pushForce = 6.0f;
	
	void OnControllerColliderHit(ControllerColliderHit hit){
		_contact = hit;
		
		Rigidbody body = hit.collider.attachedRigidbody; //для сноса физических объектов
		if (body != null && !body.isKinematic) {
			body.velocity = hit.moveDirection * pushForce;
		}
	}
	
	// Use this for initialization
	void Start () {
		_charController = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();
		_vertSpeed = minFall;
		
		//Cursor.lockState = CursorLockMode.Locked; //блокируем курсор
		//Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = Vector3.zero;
		float horInput = Input.GetAxis("Horizontal");
		float vertInput = Input.GetAxis("Vertical");
		
		if (horInput !=0 || vertInput !=0){
			movement.x = horInput * moveSpeed;
			movement.z = vertInput * moveSpeed;
			movement = Vector3.ClampMagnitude(movement, moveSpeed);
			Quaternion tmp = target.rotation; //сохраняем начальную ориентацию
			target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
			movement = target.TransformDirection(movement); //из локальных координат в глобальные
			target.rotation = tmp;
			Quaternion direction = Quaternion.LookRotation(movement);
			transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotSpeed * Time.deltaTime);
			//movement *= Time.deltaTime;
			//_charController.Move(movement);
		}
		
		_animator.SetFloat("Speed", movement.sqrMagnitude); 
		bool hitGround = false;
		RaycastHit hit;
		
		if (_vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit)){
			float check = (_charController.height + _charController.radius) / 0.7f;
			hitGround = hit.distance <= check;
			//if (hitGround == true)
			//Debug.Log(hitGround);
		}
		
		if (hitGround){//_charController.isGrounded){
			if (Input.GetButtonDown("Jump")){
				_vertSpeed = jump_Speed;
			} else {
				_vertSpeed = minFall;
				_animator.SetBool("Jumping", false);
			}
		} else {
			_vertSpeed += gravity * 5 * Time.deltaTime;
			if (_vertSpeed < terminalVelocity){
				_vertSpeed = terminalVelocity;
			}
			if (_contact != null) {
				_animator.SetBool("Jumping", true);
			}
			if (_charController.isGrounded){
				if (Vector3.Dot(movement, _contact.normal) < 0){
					movement = _contact.normal * moveSpeed;
				} else {
					movement += _contact.normal * moveSpeed;
				}
			}
		}
		
		movement.y = _vertSpeed;
		movement *= Time.deltaTime;
		_charController.Move(movement);
	}
}
