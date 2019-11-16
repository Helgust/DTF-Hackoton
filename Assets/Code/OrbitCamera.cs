using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {

	[SerializeField] private Transform target;
	
	public float rotSpeed = 1.5f;
	
	private float _rotY;
	private Vector3 _offset;
	
	void LateUpdate() {
		float horInput = Input.GetAxis("Horizontal");
		if (horInput != 0){
			_rotY += horInput * rotSpeed;
		} else {
			_rotY += Input.GetAxis("Mouse X") * rotSpeed *3;
		}
		//_rotY += 1 * rotSpeed;
		Quaternion rotation = Quaternion.Euler(0, _rotY, 0);
		//if (horInput != 0){
		//Debug.Log("ro" + rotation);
		//Debug.Log("Eul" + rotation.Euler);
		//}
		transform.position = target.position - rotation * _offset;
		//if (horInput != 0)
		//Debug.Log("pos" + transform.position);
		transform.LookAt(target);
	}
	
	// Use this for initialization
	void Start () {
		_rotY = transform.eulerAngles.y;
		_offset = target.position - transform.position;
		//_offset = new Vector3(1,1,1);
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
