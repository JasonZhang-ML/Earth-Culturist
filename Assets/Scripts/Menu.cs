using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    // public void OnStartGame(int SceneNumber){
    //     //Application.LoadLevel(SceneNumber); //Unity4.6及之前版本的写法
	// 	SceneManager.LoadScene (SceneNumber);
	// }

    public void ChangeScene(string scenename)
    {
        Application.LoadLevel(scenename);
    }

}
