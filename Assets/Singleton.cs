using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour
	where T : MonoBehaviour
{
	private static T instance;
	public static T I {
		get {
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T));
 
				if (instance == null) {
					Debug.LogError (typeof(T) + " is nothing");
				}
			}
 
			return instance;
		}
	}

    // サブクラスでオーバーライドする際は必ず呼ぶこと！
	protected virtual void OnDestroy()
	{
		if( instance == this ){
			instance = null;
		}
	}

	protected virtual void Awake()
	{
		CheckInstance();
	}
	
	protected bool CheckInstance()
	{
		if( this == I ){ return true;}
		Destroy(this);
		return false;
	}

	static public bool IsValid()
	{
		return ( instance != null ) ;
	}

	// //destory
	// public IEnumerator Clean ()
	// {
	// 	GameObject obj =  instance.gameObject;
	// 	Destroy (instance);
	// 	yield return new WaitForEndOfFrame ();

	// 	instance = obj.AddComponent<T>();
	// }
}