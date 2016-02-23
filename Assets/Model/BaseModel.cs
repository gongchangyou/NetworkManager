using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseModel
{
	// エラー情報.
	public int error = (int)App.Network.Error.None;
	public string updateUrl = "";
	public App.Network.Error Error
	{
		get { return (App.Network.Error)error; }
		set { error = (int)value; }
	}

	// チュートリアルステップ.
	public int tutorial = -1;
    
    //エリアリセットに関するデータ。すべてのAPIで降ってくるわけではないので、デフォルト値null以外の値が入っている場合のみGlobalDataManagerを更新する
//    public AreaResetInfoModel.Param areaReset = null;

	// アセットバージョン.
	[System.Serializable]
	public class AssetVersionInfo
	{
		public string name = "";
		public int version;
	}
	public List<AssetVersionInfo> assetVersion;

	// サーバーから降ってきた汎用パラメータをシステムに反映.
	public void Apply()
	{
		//各种global设置
//		if (tutorial >= 0){
//			GlobalDataManager.I.m_Tutorial.step = tutorial;
//		}
//		if (assetVersion != null)
//		{
//			GlobalDataManager.I.m_AssetVersionInfos = assetVersion;
//		}
//        if (areaReset != null)
//        {
//            GlobalDataManager.I.m_AreaResetInfo = areaReset;
//        }
	}

#if WCAT_DEVELOP
	// テストデータ設定（開発用）.
	public virtual void SetupTestData()
	{
		Debug.LogWarning("[Network] test result data does not exist.");
	}
#endif
}
