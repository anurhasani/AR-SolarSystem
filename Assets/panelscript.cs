﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class panelscript : MonoBehaviour {

   
    public GameObject Panel;
    public void hidePanel()
    {
        Panel.gameObject.SetActive(false);
    }
}
