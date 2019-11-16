using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloor : MonoBehaviour {
	
	[SerializeField] private GameObject floor;
	//[SerializeField] public GameObject Player;
	///[SerializeField] private GameObject floor;
	private float speed = 3.0f;
	private float baseSpeed = 3.0f;
	private GameObject _flor1;
	public int key = 0;
	//private GameObject _flor2;
	//private GameObject _enemy3;
	
	/*private void OnSpeedChanged(float value){
		speed = baseSpeed * value;
		WanderingAI AI = enemyPrefab.GetComponent<WanderingAI>();
		AI.SetSpeed(speed);
	}
	
	void Awake(){
		Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}
	
	void OnDestroy(){
		Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}*/
	
	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	
	public void FuncCreateFloor(GameObject obj1){
		if (obj1 != null){
			_flor1 = Instantiate(floor) as GameObject;
			float y1 = Random.Range(10, 25);
			float z1 = Random.Range(20, 35);
			float x1 = Random.Range(-15, 15);
			_flor1.transform.position = new Vector3(x1, obj1.transform.position.y-y1, obj1.transform.position.z+z1);
			float angle = Random.Range(0, 360);
			_flor1.transform.Rotate(0, angle, 0);
			key++;
		}
		/*DeviceTrigger trigger = obj2.GetComponent<DeviceTrigger>();
		trigger.OnDie();
		trigger = obj1.GetComponent<DeviceTrigger>();
		trigger.predFloor = ref this.gameObject;*/
		//float angle = Random.Range(0, 360);
		//_enemy.transform.Rotate(0, angle, 0);
	}
	
	public void FuncCreateEvent(){
		float angle = Random.Range(0, 2);
		
	}
	
	/*void Update () {
		if (_enemy == null){
			_enemy = Instantiate(enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3(20.0f, 0.0f, -25.0f);
			float angle = Random.Range(0, 360);
			_enemy.transform.Rotate(0, angle, 0);
		}
		if (_enemy2 == null){
			_enemy2 = Instantiate(enemyPrefab) as GameObject;
			_enemy2.transform.position = new Vector3(30.0f, 0.0f, -35.0f);
			float angle = Random.Range(0, 360);
			_enemy2.transform.Rotate(0, angle, 0);
		}
		if (_enemy3 == null){
			_enemy3 = Instantiate(enemyPrefab) as GameObject;
			_enemy3.transform.position = new Vector3(-10.0f, 0.0f, 0.0f);
			float angle = Random.Range(0, 360);
			_enemy3.transform.Rotate(0, angle, 0);
		}
	}*/
	// Use this for initialization
	/*void Start () {
		
	}*/
	
	// Update is called once per frame

}
