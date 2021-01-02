using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI ERROR");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;
    
    public void OpenShop(int gem_count)
    {
        playerGemCountText.text = " Gem : "+gem_count.ToString();
    }
    
    private void Awake()
    {
        _instance = this;        
    }


}

