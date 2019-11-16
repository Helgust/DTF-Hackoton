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
	private float angle = 0;
	private int localKey = 0;
	private int localKeyColor = 0;
	private float localKeyVert = 0;
	
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
		localKeyColor = 1;
		if (!(localKeyVert>0))
			Player.transform.parent = transform;
		//Player.transform.localScale = new Vector3(3*transform.localScale.x/20,3,3*transform.localScale.z/20);
		//Debug.Log(transform.localScale.x);
		if (target.key!=1){
			OnDie();
			//localKeyVert = Random.Range(-1, 1);
		}
		//}
	}
	
	private void OnTriggerExit(Collider other)
	{
		Player.transform.parent = null;
		Player.transform.localScale = new Vector3(3,3,3);
	}
	
	public void OnDie(){
		StartCoroutine(Die());
	}
	
	private IEnumerator Die(){
		yield return new WaitForSeconds(15.5f);
		Player.transform.parent = null;
		Destroy(this.gameObject);
	}
	
	//void OnTriggerExit(Collider other){
	//	foreach (GameObject target in targets)
	//		target.SendMessage("Deactivate");
	//}

	// Use this for initialization
	void Start () {
		localKeyVert = Random.Range(-1, 2);
		Debug.Log(localKeyVert);
		target = Controller.GetComponent<CreateFloor>();
		Color random = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
		if (target.key!=1)
			GetComponent<Renderer>().material.color = random;
	}
		
	void Update () {
		if (localKeyVert>0){
			if (angle == 0)
				angle = Random.Range(-15, 15);
			//if (angle < 1.0f)
			transform.Rotate(1*angle*Time.deltaTime, 0, 0);
		} else {
		if (angle == 0)
				angle = Random.Range(-130, 130);
			//if (angle < 1.0f)
			transform.Rotate(0, 1*angle*Time.deltaTime, 0);
		
		}
		/*if (localKeyColor !=0){
			Color color = GetComponent<Renderer>().material.color;
			color = new Color(color.r+((1-color.r)/17)*Time.deltaTime*Time.deltaTime, color.g-((color.g-0)/17)*Time.deltaTime*Time.deltaTime, color.b-((color.b-0)/17)*Time.deltaTime*Time.deltaTime);
			GetComponent<Renderer>().material.color = color;
		}*/
		//else 
		//	transform.Rotate(0, transform.Rotation.y-1, 0);
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
