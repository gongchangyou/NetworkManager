using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NetworkLogManager {
	static NetworkLogManager _instance;
	public static NetworkLogManager instance {
		get {
			if (_instance == null) {
				_instance = new NetworkLogManager();
			}
			return _instance;
		}
	}
	
	public enum NetworkLogType {
		Post,
		Response
	}
	
	public class NetworkLog {
		public NetworkLogType type;
		public string url;
		public string data;
	}
	
	List<NetworkLog> networkLogs = new List<NetworkLog>();
	
	public static void PostLog(string url, string data) {
		instance.AddLog(NetworkLogType.Post, url, data);
	}
	
	public static void ResponseLog(string url, string data) {
		instance.AddLog(NetworkLogType.Response, url, data);
	}
	
	void AddLog(NetworkLogType type, string url, string data){
		var log = new NetworkLog();
		log.type = type;
		log.url = url;
		log.data = data;
		
		networkLogs.Add(log);
	}
	
	public List<NetworkLog> GetLogs() {
		return networkLogs;
	}

	public void ClearLogs() {
		networkLogs.Clear();
	}
}
