using UnityEngine;
using System.Collections;

public class TestModel : BaseModel {
	public static string URL = "test.php";
	public Param result =new Param();
	public class Param {
		public string name;
		public int age;

	}
}
