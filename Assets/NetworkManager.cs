
//#define USE_REQUEST_MSGPACK
//#define USE_RECEIVE_MSGPACK
#if WCAT_DEVELOP
//#define USE_DEBUG_TESTDATA
#endif
//#define REGION_TAIWAN

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;


public partial class NetworkManager : Singleton<NetworkManager>
{
	//for CN_USE_SDK_MORNINGTEC
	//public const string GAMEZONE_HOST = "http://192.168.1.102:10001/";
#if WCAT_CBT
	public const string GAMEZONE_HOST = "http://cbt3.wcat.gumichina.com/";
	public static string APP_HOST = "http://cbt3.wcat.gumichina.com/";
	public static string IMG_HOST = "http://cbt3.wcat.gumichina.com/";
	public static string PUBLIC_HOST = "http://cbt3.wcat.gumichina.com/";
#elif WCAT_REVIEW

        public const string GAMEZONE_HOST = "http://review.g.baimaojihua.com/";
        public static string APP_HOST = "http://review.g.baimaojihua.com/";
        public static string IMG_HOST = "http://review.g.baimaojihua.com/";
        public static string PUBLIC_HOST = "http://review.g.baimaojihua.com/";

#elif WCAT_STAGING

	//TODO: 除了 IOS正式版其他还没好

	//IOS正式版独立一个大区
	// 或带晨之科SDK的AppStore渠道
	#if ((UNITY_IPHONE && !CN_USE_SDK) || (UNITY_IPHONE && CN_USE_SDK && CN_USE_SDK_MORNINGTEC_IOS))

		public const string GAMEZONE_HOST = "http://staging.ios.baimaojihua.com/";
		public static string APP_HOST = "http://staging.ios.baimaojihua.com/";
		public static string IMG_HOST = "http://staging.ios.baimaojihua.com/";
		public static string PUBLIC_HOST = "http://staging.ios.baimaojihua.com/";

	//安卓 UC 360 baidu and ios 91 一个大区
	#elif (UNITY_ANDROID && ( CN_USE_SDK_UC || CN_USE_SDK_360 || CN_USE_SDK_BaiDu )) || (UNITY_IPHONE && CN_USE_SDK_91)

		public const string GAMEZONE_HOST = "http://staging.and1.baimaojihua.com/";
		public static string APP_HOST = "http://staging.and1.baimaojihua.com/";
		public static string IMG_HOST = "http://staging.and1.baimaojihua.com/";
		public static string PUBLIC_HOST = "http://staging.and1.baimaojihua.com/";

	//安卓其他平台和IOS越狱版一个大区
	#else

		public const string GAMEZONE_HOST = "http://staging.and2.baimaojihua.com/";
		public static string APP_HOST = "http://staging.and2.baimaojihua.com/";
		public static string IMG_HOST = "http://staging.and2.baimaojihua.com/";
		public static string PUBLIC_HOST = "http://staging.and2.baimaojihua.com/";

	#endif

#elif WCAT_REVIEW
        
        #if UNITY_ANDROID
                
                public const string GAMEZONE_HOST = "http://review.g.baimaojihua.com/";
                public static string APP_HOST = "http://review.g.baimaojihua.com/";
                public static string IMG_HOST = "http://review.g.baimaojihua.com/";
                public static string PUBLIC_HOST = "http://review.g.baimaojihua.com/";

        #endif

#elif WCAT_RELEASE

	//IOS正式版独立一个大区
	// 或带晨之科SDK的AppStore渠道
	#if ((UNITY_IPHONE && !CN_USE_SDK) || (UNITY_IPHONE && CN_USE_SDK && CN_USE_SDK_MORNINGTEC_IOS))

		public const string GAMEZONE_HOST = "http://ios.g.baimaojihua.com/";
		public static string APP_HOST = "http://ios.g.baimaojihua.com/";

		public static string IMG_HOST = "http://ios.g.baimaojihua.com/";
		public static string PUBLIC_HOST = "http://ios.g.baimaojihua.com/";

	//安卓 UC 360 baidu and ios 91 一个大区
	#elif (UNITY_ANDROID && ( CN_USE_SDK_UC || CN_USE_SDK_360 || CN_USE_SDK_BaiDu )) || (UNITY_IPHONE && CN_USE_SDK_91)

		public const string GAMEZONE_HOST = "http://and1.g.baimaojihua.com/";
		public static string APP_HOST = "http://and1.g.baimaojihua.com/";
		public static string IMG_HOST = "http://and1.g.baimaojihua.com/";
		public static string PUBLIC_HOST = "http://and1.g.baimaojihua.com/";

	//安卓其他平台和IOS越狱版一个大区
	#else

		public const string GAMEZONE_HOST = "http://and2.g.baimaojihua.com/";
		public static string APP_HOST = "http://and2.g.baimaojihua.com/";
		public static string IMG_HOST = "http://and2.g.baimaojihua.com/";
		public static string PUBLIC_HOST = "http://and2.g.baimaojihua.com/";

	#endif
#elif COOP_DEBUG && UNITY_ANDROID	// 跨大区协力测试
	public const string GAMEZONE_HOST = "http://42.62.24.203:80/";
	public static string APP_HOST = "http://42.62.24.203:80/";
	public static string IMG_HOST = "http://42.62.24.203:80/";
	public static string PUBLIC_HOST = "http://42.62.24.203:80/";
#elif BS_REVIEW
	public const string GAMEZONE_HOST = "http://dev02.wcat.gumichina.com/";
	public static string APP_HOST = "http://dev02.wcat.gumichina.com/";
	public static string IMG_HOST = "http://dev02.wcat.gumichina.com/";
	public static string PUBLIC_HOST = "http://dev02.wcat.gumichina.com/";	
#else
	public const string GAMEZONE_HOST = "http://dev01.wcat.gumichina.com/";
	public static string APP_HOST = "http://zhansanguo.sinaapp.com/";
	public static string IMG_HOST = "http://dev01.wcat.gumichina.com/";
	public static string PUBLIC_HOST = "http://dev01.wcat.gumichina.com/";
#endif


#if WCAT_STAGING

	//安卓 UC 360 baidu and ios 91 一个大区
	#if (UNITY_ANDROID && ( CN_USE_SDK_UC || CN_USE_SDK_360 || CN_USE_SDK_BaiDu )) || (UNITY_IPHONE && CN_USE_SDK_91)

		public static string PAY_HOST = "http://and1.iap.baimaojihua.com/";

	//安卓其他平台和IOS越狱版一个大区
	#else

		public static string PAY_HOST = "http://and2.iap.baimaojihua.com/";

	#endif

#elif WCAT_RELEASE

	//安卓 UC 360 baidu and ios 91 一个大区
	#if (UNITY_ANDROID && ( CN_USE_SDK_UC || CN_USE_SDK_360 || CN_USE_SDK_BaiDu )) || (UNITY_IPHONE && CN_USE_SDK_91)

		public static string PAY_HOST = "http://and1.iap.baimaojihua.com/";

	//安卓其他平台和IOS越狱版一个大区
	#else

		public static string PAY_HOST = "http://and2.iap.baimaojihua.com/";

	#endif

#else

	public static string PAY_HOST = APP_HOST;

#endif

	#if CN_USE_SDK_BiLi || CN_USE_SDK_ShareJoy
	public static int platformServerId;
	#endif

	// WWW オブジェクトリスト（プログレス取得用）
	[System.Serializable]
	public class WWWInfo
	{
		public WWW www;
		public bool isAssetData;
		public bool isCached;

		public WWWInfo() {}
		public WWWInfo(WWW _www, bool _isAssetData, bool _isCached)
		{
			www = _www;
			isAssetData = _isAssetData;
			isCached = _isCached;
		}
	}
	public List<WWWInfo> m_WWWInfos = new List<WWWInfo>();

	// ユーザー認証トークン
	public string m_Token { get { return "token_string"; } }//return GlobalDataManager.I.m_Account.token; } }
	public string m_UserHash { get { return "userHashuserHashuserHash"; } }// return GlobalDataManager.I.m_Account.userHash; } }
	public string m_TokenTemp; // Cookieにあるtokenを保持しておく為の一時的なバッファ.
#if REGION_TAIWAN
	private const string TOKEN_KEY = "wcattwpt";
#else
	private const string TOKEN_KEY = "wcatpt";
#endif
	
#if USE_REQUEST_MSGPACK || USE_RECEIVE_MSGPACK
	// パーサー
	private MsgPack.ObjectPacker m_Packer = new MsgPack.ObjectPacker();
#endif

#if !USE_RECEIVE_MSGPACK
	// エラー検知用
	private const string EMPTY_RECORD_RESULT = "\"result\":[]";
	private const string EMPTY_RECORD_JSON = "{\"error\":0," + EMPTY_RECORD_RESULT + "}";
#endif

	void Update()
	{
		// WWW配列を監視 詰んである通信が全て終わっていれば破棄.
		var count = m_WWWInfos.Count;
		if (count > 0)
		{
			var completeInfos = m_WWWInfos.FindAll(i => i.www == null);
			if (completeInfos.Count == count)
			{
//				Debug.Log("[N] www infos are cleared.");
				m_WWWInfos.Clear();
			}
		}
	}
	// Preload.
	private bool m_isPreload = false;

	public void SetPreload(bool bEnable)
	{
		m_isPreload = bEnable;
	}

	public bool IsNotPreload()
	{
		return !m_isPreload;
	}

	// HTTP リクエスト（POST無し）
	public void Request<T>(string path, System.Action<T> onComplete, string getParam = "" , int serverindex = 0 , bool isStatic = false) where T : BaseModel, new()
	{
		StartCoroutine(RequestCoroutine(path, onComplete, getParam , serverindex , isStatic));
	}
	public IEnumerator RequestCoroutine<T>(string path, System.Action<T> onComplete, string getParam = "" , int serverindex = 0 , bool isStatic = false) where T : BaseModel, new()
	{

#if UNITY_EDITOR
		string url = APP_HOST + path + getParam;
		NetworkLogManager.PostLog(url, "");
#endif

		yield return StartCoroutine(RequestFormCoroutine (path, null, onComplete, getParam , serverindex , isStatic));

	}

	// HTTP リクエスト（POST有り ユーザー定義型指定）
	public void Request<T1, T2>(string path, T1 postData, System.Action<T2> onComplete, string getParam = "" , int serverindex = 0) where T2 : BaseModel, new()
	{
		StartCoroutine(RequestCoroutine(path, postData, onComplete, getParam , serverindex ));
	}
	public IEnumerator RequestCoroutine<T1, T2>(string path, T1 postData, System.Action<T2> onComplete, string getParam = "" , int serverindex = 0) where T2 : BaseModel, new()
	{
		var form = new WWWForm ();
#if USE_REQUEST_MSGPACK
		var data = m_Packer.Pack(postData);
		form.AddBinaryData ("data", data);
		var debugString = JSONSerializer.Serialize(postData);
		Debug.Log("[Network] request add data field: " + debugString);
#else
		var data = JSONSerializer.Serialize(postData, postData.GetType());

		string encryptedData = null;
		string key = string.IsNullOrEmpty(m_UserHash) ? Cipher.DEFAULT_NETWORKHASH : m_UserHash;
#if !UNITY_EDITOR && UNITY_ANDROID
		using (AndroidJavaClass clazz = new AndroidJavaClass("jp.colopl.wcat.StartActivity")) {
			using (AndroidJavaObject activity = clazz.GetStatic<AndroidJavaObject>("act")) {
				encryptedData = System.Convert.ToBase64String(activity.Call<byte[]>("encryptMessage", Encoding.UTF8.GetBytes(key), Encoding.UTF8.GetBytes(data)));
			}
		}
#else
		encryptedData = Cipher.EncryptRJ128(key, Cipher.DEFAULT_IV_128_REQ, data);
#endif
		string dataToSend = !string.IsNullOrEmpty(encryptedData) ? encryptedData : "";

		form.AddField ("data", dataToSend);

		Debug.Log("[Network] request add data field: " + data);
		Debug.Log("[Network] dataToSend data: " + dataToSend);
		
#if UNITY_EDITOR
		string url = APP_HOST + path + getParam;
		NetworkLogManager.PostLog(url, data);
#endif

#endif
		yield return StartCoroutine(RequestFormCoroutine (path, form, onComplete, getParam , serverindex ));
	}

	// HTTP リクエスト（POST有り WWWForm指定）
	public void RequestForm<T>(string path, WWWForm form, System.Action<T> onComplete, string getParam = "",int serverindex = 0) where T : BaseModel, new()
	{
		StartCoroutine(RequestFormCoroutine(path, form, onComplete, getParam , serverindex ));
	}
	public IEnumerator RequestFormCoroutine<T>(string path, WWWForm form, System.Action<T> onComplete, string getParam = "" , int serverindex = 0 , bool isStatic = false ) where T : BaseModel, new()
	{
		// add version info
		if (form == null)
			form = new WWWForm();

		yield return StartCoroutine(Request_Impl<T>(path, form, onComplete, () => {
			// fatal error
		}, getParam , serverindex , isStatic ));
	}

	#region China
	public HashSet<System.Action<string>> hooks = new HashSet<System.Action<string>>();
	private void CallHooks( string msg )
	{
		foreach (System.Action<string> a in hooks)
		{
			a(msg);
		}
	}
	#endregion

	// HTTP 通信
	private IEnumerator Request_Impl<T>(string path, WWWForm form, System.Action<T> onComplete, System.Action onFatal, string getParam = "" , int serverindex = 0 , bool isStatic = false ) where T : BaseModel, new()
	{
		SetPreload(false);

		string url = path + getParam;
		switch(serverindex)
		{
			case 0:
				url = APP_HOST + url;
				break;
			case 1:
				url = GAMEZONE_HOST + url;
				break;
			case 2:
				url = PUBLIC_HOST + url;
				break;
			case 3:
				url = IMG_HOST + url;
				break;
		}
		// string url = APP_HOST + path + getParam;
		if (form == null){
			form = new WWWForm();
		}

		// 最低でも一つのフィールドをPOSTに含める.
		form.AddField("app", "wcat");
#region China purchasetype no use
/*
#if UNITY_ANDROID
		int purchaseType = Native.GetPurchaseType();
		form.AddField("purchasetype", purchaseType);
#endif
*/
#endregion
		// post data
		var data = form.data;

		// header
		var headers = form.headers;
//		if (string.IsNullOrEmpty(m_Token) == false)
		headers["Cookie"] = m_Token ?? "";
		Debug.Log("Cookie token : " + headers["Cookie"]);

		// Appバージョン情報を付与.
//		headers["apv"] = NetworkNative.getNativeVersionName();

#if ! UNITY_EDITOR
	#if UNITY_IPHONE
		headers["User-Agent"] = NetworkNative.getDefaultUserAgent();
	#endif
#endif

#if USE_REQUEST_MSGPACK
		headers["Content-Type"] = "application/x-msgpack";
		headers["charset"] = "x-user-defined";
//		headers["Content-Type"] = "application/octet-stream";
#endif

		// result
		var txt = "Empty";
		var msg = CreateErrorMsg(App.Network.Error.Unknown);

		// request
		Debug.Log ("[Network] request: " + url);

#if WCAT_DEVELOP
		// 仮
		bool isConnect = true;

		// 無効なURLを検知
		if (string.IsNullOrEmpty(path)) {
			msg = CreateErrorMsg(App.Network.Error.InvalidURL);
			isConnect = false;
		}

		// force error
		if (DebugManager.isForceNetworkError) {
			msg = CreateErrorMsg(App.Network.Error.DebugForceError);
			isConnect = false;
		}
		if (DebugManager.isForceNetworkRandomError) {
			msg = CreateErrorMsg((App.Network.Error)Random.Range(1, int.MaxValue));
			isConnect = false;
		}
		if (DebugManager.isForceNetworkErrorMaintenance) {
			msg = CreateErrorMsg(App.Network.Error.ERR_MAINTENANCE);
			isConnect = false;
		}
		if (DebugManager.isForceNetworkErrorUpdateForce) {
			msg = CreateErrorMsg(App.Network.Error.ERR_UPDATE_FORCE);
			isConnect = false;
		}
		if (DebugManager.isForceNetworkErrorBAN) {
			msg = CreateErrorMsg(App.Network.Error.ERR_BAN_USER);
			isConnect = false;
		}
		if(isConnect)
#endif
		{
			using(var www = new WWW(url, data, headers))
			{
				var wwwinfo = new WWWInfo(www, false, false);
				m_WWWInfos.Add(wwwinfo);
				
				float timeouttimer = 0.0f;
				float lastProgress = 0f;
				
				do {
					yield return new WaitForEndOfFrame();
					// check self time out
					var progress = www.progress;
					if (lastProgress == progress)
					{
						timeouttimer += Time.deltaTime;
//						Debug.Log("[NH] [P]" + progress + " [T]" + timeouttimer);
					}
					else
					{
						timeouttimer = 0f;
//						Debug.Log("[NH] [P]" + lastProgress + "->" + progress + " [T]" + timeouttimer);
						lastProgress = progress;
					}
					if (timeouttimer > 15f)
					{	
						msg = CreateErrorMsg(App.Network.Error.TimeOut);
						break;
					}

					// check success
					if (www.isDone)
					{
						// check fail
						if (string.IsNullOrEmpty(www.error) == false)
						{
							txt = www.error;
							int httpError = 0;
							if (int.TryParse(www.error.Substring(0, 3), out httpError)){
								msg = CreateErrorMsg(App.Network.Error.DetectHttpError + httpError);
							}
							else {
								msg = CreateErrorMsg(App.Network.Error.DetectHttpError);
							}
							break;
						}
						
						txt = www.text;
						if(isStatic)
						{
							msg = txt;
							break;
						}

						#region China fix cookies bug
						string headerstring = "url :" + www.url + "\nheader :\n";
						#endregion

						//bool isResponseEncrypted = false;
						string signature = null;
						foreach(var header in www.responseHeaders)
						{
							#region China fix cookies bug
							headerstring += header.Key.ToLower() + ": " +  header.Value.ToLower() + "\n";
							#endregion

							//Debug.Log ("h: "+ header.Key.ToLower() + ": " +  header.Value.ToLower());
							string headerName = header.Key.ToLower();
							// cookieからtoken検出
							if (string.IsNullOrEmpty(m_TokenTemp) && headerName == "set-cookie") {
								var values = new List<string>(header.Value.Split(';'));
								foreach(var value in values) {
									if (value.Contains(TOKEN_KEY))  {
										m_TokenTemp = value;
									}
								}
							}
							else if(headerName == "x-compress-encrypt") {
								if( header.Value.Trim() == "cipher" ){
									//isResponseEncrypted = true;
								}
							}
							else if(headerName == "x-signature") {
								signature = header.Value.Trim();
							}
						}

						#region China fix cookies bug
						if (string.IsNullOrEmpty(m_TokenTemp))
						{
							Dictionary<string,string> cookies = UnityCookies.ParseCookies(www);
							if (cookies.ContainsKey(TOKEN_KEY)) {
								var values = new List<string>(UnityCookies.GetRawCookieString(www).Split(';'));
								foreach(var value in values) {
									if (value.Contains(TOKEN_KEY))  {
//										Debug.LogError("real cookie :" + value);
										m_TokenTemp = value;
									}
								}
//								m_TokenTemp = TOKEN_KEY + "=" + cookies.GetValueOrDefault(TOKEN_KEY);

							}
						}
//						Debug.LogError(headerstring);
//						Debug.LogError(string.IsNullOrEmpty(m_TokenTemp) ? "" : m_TokenTemp);
						#endregion

						// 複合化.
						bool isDecryptSuccess = true;
						byte[] gzippedResponse = null;
						try {
							Debug.Log("user hash : " + m_UserHash + " - " + Cipher.DEFAULT_NETWORKHASH);
							string key = string.IsNullOrEmpty(m_UserHash) ? Cipher.DEFAULT_NETWORKHASH : m_UserHash;
							// decrypt whatever the value of isResponseEncrypted is.
							gzippedResponse = Cipher.DecryptRJ128Byte(key, Cipher.DEFAULT_IV_128_RES, www.text);
						}
						catch(System.Exception exc) {
							Debug.LogError(exc);
							isDecryptSuccess = false;
						}
						if( !isDecryptSuccess )
						{
							// uhを使用して失敗したのであれば、デフォルトキーで複合化を試みる.
							if (!string.IsNullOrEmpty(m_UserHash))
							{
								isDecryptSuccess = true;
								try {
									gzippedResponse = Cipher.DecryptRJ128Byte(Cipher.DEFAULT_NETWORKHASH, Cipher.DEFAULT_IV_128_RES, www.text);
								}
								catch(System.Exception exc) {
									Debug.LogError(exc);
									isDecryptSuccess = false;
								}
								if( !isDecryptSuccess ){
									msg = CreateErrorMsg(App.Network.Error.DecryptFailed);
									Debug.LogError("Decrypt failed");
									break;
								}
							}
							// uhの無い状態で複合化が失敗した.
							else
							{
								msg = CreateErrorMsg(App.Network.Error.DecryptFailedByDefaultKey);
								Debug.LogError("Decrypt failed!!!");
								break;
							}
						}
						if( gzippedResponse == null ){
							msg = CreateErrorMsg(App.Network.Error.DecryptResponceIsNull);
							Debug.LogError("Decrypt responce is null");
							break;
						}

						// 解凍.
						bool isUncompressSuccess = true;
						try {
							msg = GzUncompress(gzippedResponse);
						}
						catch(System.Exception exc) {
							Debug.LogError(exc);
							isUncompressSuccess = false;
						}
						if (!isUncompressSuccess ){
							msg = CreateErrorMsg(App.Network.Error.UncompressFailed);
							break;
						}
						txt = msg;

						// 署名.
						if( signature == null )
						{
							msg = CreateErrorMsg(App.Network.Error.SignatureIsNull);
							Debug.LogError("Signature is null");
							break;
						}

						// 署名エラー検出.
						bool isVerifySignatureSuccess = true;
						bool isValidSignature = true;
						try {
							isValidSignature = Cipher.verify(msg, signature);
						}
						catch(System.Exception exc){
							Debug.LogError(exc);
							isVerifySignatureSuccess = false;
						}
						if (!isVerifySignatureSuccess) {
							msg = CreateErrorMsg(App.Network.Error.VerifySignatureFailed);
							Debug.Log ("Verify signature failed.");
							break;
						}
						else if(!isValidSignature) {
							msg = CreateErrorMsg(App.Network.Error.InvalidSignature);
							Debug.Log ("Signature is invalid");
							break;
						}

						// エスケープ.
						msg = System.Text.RegularExpressions.Regex.Unescape(msg);

#if !USE_RECEIVE_MSGPACK
						// 空のJSONを検知
						if (msg == EMPTY_RECORD_JSON){
							msg = CreateErrorMsg(App.Network.Error.EmptyRecord);
						}
#endif
#if !USE_RECEIVE_MSGPACK
						// 空のリザルト値を削除
						if (msg.Contains(EMPTY_RECORD_RESULT)){
							msg = msg.Replace(EMPTY_RECORD_RESULT, "\"dummy\":[]");
						}
#endif
						break;
					}
				}
				while(true);
				wwwinfo.www = null;
//				m_WWWInfos.Remove(wwwinfo);
			}
		}
#if USE_RECEIVE_MSGPACK
		Debug.Log("[Network] msg: " + msg.Length + " Byte data");
#else
		Debug.Log("[Network] receive (txt): " + txt);
		Debug.Log("[Network] receive (msg): " + msg);
#endif
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();
		yield return new WaitForEndOfFrame();


		// callback result
		try
		{
			if (onComplete != null)
			{
				T ret = new T();
				try
				{
#if USE_RECEIVE_MSGPACK
					ret = m_Packer.Unpack<T>(msg);

					var debugString = JSONSerializer.Serialize(ret);
					Debug.Log("[Network] receive: " + debugString);
#else
					ret = JSONSerializer.Deserialize<T>(msg);
#endif

#if UNITY_EDITOR
					NetworkLogManager.ResponseLog(url, msg);
#endif

#if WCAT_DEVELOP
					if (DebugManager.isForceNetworkRecieveError && ret.Error == App.Network.Error.None) {
						msg = CreateErrorMsg(App.Network.Error.DebugForceError);
						ret = JSONSerializer.Deserialize<T>(msg);
					}
#endif
				}
				catch(System.Exception exp)
				{
					var decodeFailedMsg = CreateErrorMsg(App.Network.Error.DecodeFailed);
#if USE_RECEIVE_MSGPACK
					ret = m_Packer.Unpack<T>(decodeFailedMsg);
#else
					ret = JSONSerializer.Deserialize<T>(decodeFailedMsg);
#endif
					Debug.LogException(exp);
				}
				finally
				{
#if USE_DEBUG_TESTDATA
					// エラーを検出したらテストデータを設定する
					if (ret.Error != App.Network.Error.None)
					{
						Debug.LogWarning("[Network] setup test result data. ERROR: " + ret.Error + " TYPE: " + ret.GetType());
						ret.SetupTestData();
					}
#else
					// エラーを検出
					if (ret.Error != App.Network.Error.None)
						Debug.LogError(string.Format("[Network] Error: {0} ({1})", ret.Error, ret.error));
#endif
					ret.Apply();
					#region china vk update 
					if(ret.Error == App.Network.Error.ERR_UPDATE_FORCE){
						Debug.LogError("force update");
//					UIManager.I.CommonUI.OpenDialog(Dialog.Type.OK, MessageManager.I.GetMessage(Message.Common_msg.ERR_UPDATE_FORCE), (sel)=>{
//							if(!string.IsNullOrEmpty(ret.updateUrl)){
//								Application.OpenURL(ret.updateUrl);
//								Application.Quit();
//							}else{
//								SceneManager.ChangeOutGame(OutGameManager.Scene.Reset);
//							}
//						});
					}else{
					onComplete(ret);
					#region China
					CallHooks(msg);
					#endregion
				   }
				 #endregion	
				}
			}
		}
		catch(System.Exception exp)
		{
			Debug.LogException(exp);
			onFatal();
		}
	}

#if USE_RECEIVE_MSGPACK
	private byte[] CreateErrorMsg(App.Network.Error error)
	{
		var model = new BaseModel();
		model.error = (int)error;
		var ret = m_Packer.Pack(model);
		return ret;
	}
#else
	private string CreateErrorMsg(App.Network.Error error)
	{
		return "{\"error\":" + (int)error + "}";
	}
#endif

	public bool IsConnecting()
	{
//		m_WWWInfos.RemoveAll(i => i.www == null);
		var wwwInfos = m_WWWInfos.FindAll(i => !i.isCached && i.www != null);
		return wwwInfos.Count > 0;
	}

	//------------------------------------------------------------------

	// 仮
	public bool m_IsOnlineMode = false;
	
	// セッション作成
	public void CreateSession()
	{
#if USE_NETWORKVIEW
		m_NetworkState = NetworkState.Connecting;
		var error = Network.InitializeServer(3, 8106, !Network.HavePublicAddress());
		Debug.Log(error);
		if(error != NetworkConnectionError.NoError){
			m_NetworkState = NetworkState.None;
		}
#endif
	}

	// セッション検索
	public void SearchSession()
	{
#if USE_NETWORKVIEW
		MasterServer.RequestHostList(GameTypeName);
#endif
	}

	// セッション検索結果取得
	public List<HostData> GetSessionList()
	{
#if USE_NETWORKVIEW
		return new List<HostData>(MasterServer.PollHostList());
#else
		return null;
#endif
	}

	// セッション参加
	public void JoinSession(HostData hostData)
	{
#if USE_NETWORKVIEW
		m_NetworkState = NetworkState.Connecting;
		var error = Network.Connect(hostData);
		Debug.Log(error);
		if(error != NetworkConnectionError.NoError){
			m_NetworkState = NetworkState.None;
		}
#endif
	}

	// セッション離脱
	public void LeaveSession()
	{
#if USE_NETWORKVIEW
		Network.Disconnect();
		MasterServer.UnregisterHost();
#endif
	}

#if USE_NETWORKVIEW
	//
	public enum NetworkState {
		None,
		Connecting,
	}
	public NetworkState m_NetworkState { get; private set;}

	//
	private const string GameTypeName = "4709be7ac35338fb4ef58be4a4b1eed0";
	//
	private const string GameName = "gameName";
	
	// guest message
	void OnConnectedToServer()
	{
		Debug.Log("OnConnectedToServer");
		m_NetworkState = NetworkState.None;
	}
	void OnFailedToConnect(NetworkConnectionError error)
	{
		Debug.Log("OnFailedToConnect: " + error);
		m_NetworkState = NetworkState.None;
	}
	void OnDisconnectedFromServer(NetworkDisconnection info)
	{
		Debug.Log("OnDisconnectedFromServer: " + info);
		m_NetworkState = NetworkState.None;
	}

	// host message
	void OnServerInitialized()
	{
		Debug.Log("OnServerInitialized");
		m_NetworkState = NetworkState.None;
		MasterServer.RegisterHost(GameTypeName, GameName, "comment");
	}
	void OnPlayerConnected(NetworkPlayer player)
	{
		Debug.Log("OnPlayerConnected: " + player.ipAddress + ":" + player.port);
		m_NetworkState = NetworkState.None;
	}
	void OnPlayerDisconnected(NetworkPlayer player)
	{
		Debug.Log("OnPlayerDisconnected: " + player.ipAddress + ":" + player.port);
		m_NetworkState = NetworkState.None;
	}

	void OnGUI()
	{
		if(Network.isServer || Network.isClient)
		{
			GUI.Box(new Rect(10,10,100,20), Network.isServer ? "HOST" : "GUEST");
		}
	}
#endif

#if false
	public bool m_ForceUseGetParam = false;
	void GetParamTest()
	{
		bool useGetParam = false;
		var fields = new List<System.Reflection.FieldInfo>(postData.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance));
		if (m_ForceUseGetParam)
		{
			var a = from p in ;
		}
		foreach (var fi in fields)
		{
			if (fi.Name == "test"){
				useGetParam = true;
				break;
			}
		}
		if (useGetParam)
		{
			foreach (var fi in fields)
			{
				var param = fi.Name + "=" + fi.GetValue(postData);
				getParam += (getParam == "" ? "?" : ",") + param;
			}
		}
	}
#endif

	public string GetPtCookieValue() {
		return m_Token;
	}

	public static string GzUncompress(byte[] gzEncrypted) {
		byte[] decBytes = Ionic.Zlib.ZlibStream.UncompressBuffer(gzEncrypted);
		string decompressed = System.Text.Encoding.UTF8.GetString(decBytes);
		return decompressed;
	}   
	
	public static byte[] GzUncompressByte(byte[] gzEncrypted) {
		byte[] decBytes = Ionic.Zlib.ZlibStream.UncompressBuffer(gzEncrypted);
		return decBytes;
	}   

	public static byte[] GzCompress(string decrypted) {
		Debug.Log(decrypted);
		byte[] encryptedBytes = Ionic.Zlib.GZipStream.CompressString(decrypted);
		return encryptedBytes;
	}   
}
