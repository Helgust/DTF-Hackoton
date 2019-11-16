using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceTrigger : MonoBehaviour {
	//[SerializeField] private GameObject[] targets;
	//public bool requireKey;
	[SerializeField] private GameObject Controller;
	[SerializeField] private GameObject Player;
	//[SerializeField] public GameObject predFloor;
	private CreateFloor target;
	float angle = 0;
	int localKey = 0;
	
	void OnTriggerEnter(Collider other){
		//foreach (GameObject target in targets){
			//if (requireKey && Managers.Inventory.equippedItem != "key"){
			//	return;
			//}
			//target.SendMessage("Activate");
		//}
		//if (target != null){
		if (localKey == 0){
			target.FuncCreateFloor(this.gameObject);//, predFloor);
			localKey++;
		}
		Player.transform.parent = transform;
		if (target.key!=1)
			OnDie();
		//}
	}
	
	private void OnTriggerExit(Collider other)
	{
		Player.transform.parent = null;
	}
	
	public void OnDie(){
		StartCoroutine(Die());
	}
	
	private IEnumerator Die(){
		yield return new WaitForSeconds(5.5f);
		Destroy(this.gameObject);
	}
	
	//void OnTriggerExit(Collider other){
	//	foreach (GameObject target in targets)
	//		target.SendMessage("Deactivate");
	//}

	// Use this for initialization
	void Start () {
		target = Controller.GetComponent<CreateFloor>();
		Color random = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
		if (target.key!=1)
			GetComponent<Renderer>().material.color = random;
	}
		
	void Update () {
		if (angle == 0)
			angle = Random.Range(-3, 3);
		//if (angle < 1.0f)
			transform.Rotate(0, 1*angle, 0);
		//else 
		//	transform.Rotate(0, transform.Rotation.y-1, 0);
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
