﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class IGameManager : MonoBehaviour {

	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
//}

public interface IGameManager {
	ManagerStatus status {get;}
	void Startup();
}
