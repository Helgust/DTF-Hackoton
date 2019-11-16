using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager {
	
	public ManagerStatus status {get; private set;} //свойство читается откуда угодно, но задается только внутри сценария
	//private List<string> _items; 
	private Dictionary<string, int> _items;//здесь храним элементы
	public string equippedItem {get; private set;}
	
	public void Startup(){
		Debug.Log("Inventory manager starting");
		_items = new Dictionary<string, int>();
		status = ManagerStatus.Started;
	}
	
	public List<string> GetItemList(){
		List<string> list = new List<string>(_items.Keys); //возвращаем список всех ключей словаря
		return list;
	}
	
	public int GetItemCount(string name){ //возвращаем количество указанных элементов в инвентаре
		if (_items.ContainsKey(name)){
			return _items[name];
		}
		return 0;
	}
	
	private void DisplayItems(){
		string itemDisplay = "Items: ";
		foreach (KeyValuePair<string, int> item in _items){
			itemDisplay += item.Key + "(" + item.Value + ")";
		}
		Debug.Log(itemDisplay);
	}
	
	public void AddItem(string name){
		if (_items.ContainsKey(name)){ //провекра существующих записей перед вводом новых данных
			_items[name] += 1;
		} else {
			_items[name] = 1;
		}
		//_items.Add(name);
		DisplayItems();
	}
	
	public bool EquipItem(string name){
		if (_items.ContainsKey(name) && equippedItem != name){ //проверяем наличие в инвинтаре указанного элемента и тот факт, что он еще не подготовлен к использованию.
			equippedItem = name;
			Debug.Log("Equipped " + name);
			return true;
		}
		equippedItem = null;
		Debug.Log("Unequipped");
		return false;
	}
	
	public bool ConsumeItem(string name){
		if (_items.ContainsKey(name)){
			_items[name]--;
			if (_items[name]==0){
				_items.Remove(name);
			}
		} else {
			Debug.Log("cannot consume " + name);
			return false;
		}
		DisplayItems();
		return true;
	}
	
	// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
