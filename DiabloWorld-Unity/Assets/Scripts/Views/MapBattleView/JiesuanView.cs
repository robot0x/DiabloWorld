using UnityEngine;
using System.Collections;
// 战斗结束视图
public class JiesuanView : MonoBehaviour {
	
	public UILabel			labelExp, labelGold, labelTili;
	public UISprite			spriteStarPrefab;
	public Transform[]		starPos;
	public UISprite			spriteBg;
	public UIImageButton	btn;
	
	private bool 			m_Success;
	private Data_MapBattle_R.SetData m_data;
	
	public void show (bool bSuccess, Data_MapBattle_R.SetData data){
		m_data = data;
		m_Success = bSuccess;
		if (bSuccess) {  // 战斗胜利
			spriteBg.spriteName = "succ";
			btn.normalSprite = "get1";
			btn.hoverSprite = "get";
			btn.pressedSprite = "get";
			btn.GetComponentInChildren<UISprite>().spriteName = "get1";
		}
		else {  // 战斗结束
			spriteBg.spriteName = "fail";
			btn.normalSprite = "ok1";
			btn.hoverSprite = "ok";
			btn.pressedSprite = "ok";
			btn.GetComponentInChildren<UISprite>().spriteName = "ok1";
		}
		labelExp.text = "+" + m_data.exp;
		labelGold.text = "+" + m_data.coin;
		labelTili.text = "" + m_data.huoli;
		for (int i = 0; i < m_data.star; i++) {  // 显示星星
			UISprite spStar = (UISprite)GameObject.Instantiate(spriteStarPrefab);
			NGUIUtility.SetParent(transform, spStar.transform);
			Hashtable args = new Hashtable();
			args.Add("position", starPos[i].localPosition);
			args.Add("islocal", true);
			args.Add("time", 0.5f);
			args.Add("delay", 0.1f * i);			
			iTween.MoveTo(spStar.gameObject, args);
		}
	}
	
	void onClick (){  // 点击结束
		GameObject.Destroy(gameObject);
		Globals.It.EndBattleToMainView();
	}
}
