﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class UnityAdController : MonoBehaviour {

    public static bool showAds = true;

    /// <summary>
    /// Metodo responsável por exibir a tela de anuncios
    /// </summary>
    public static void ShowAd()
    {

#if UNITY_ADS
        ShowOptions opcoes = new ShowOptions();
        opcoes.resultCallback = Unpause;

        if(Advertisement.IsReady()){
            Advertisement.Show(opcoes);

            PauseMenu.onPause = true;
            Time.timeScale = 0;
        }
#endif
    }

#if UNITY_ADS
    public static void Unpause(ShowResult result)
    {
        if(ShowResult.Skipped == result){
            Time.timeScale = 1;
            PauseMenu.onPause = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }else{
            PauseMenu.onPause = false;
            Time.timeScale = 1;
        }
    }
#endif

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
