/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minimap {

    public class MinimapWindow : MonoBehaviour {
        
        //public static event EventHandler OnWindowShow;
        //public static event EventHandler OnWindowHide;

        private static MinimapWindow instance;

        public static GameObject minimapUnhide;

        private void Awake() {
            instance = this;
            //minimapUnhide = GameObject.Find("minimapUnhide");
            minimapUnhide.SetActive(true);
            instance.gameObject.SetActive(false);
        }

        public static void Show() {
            if (minimapUnhide != null)
                minimapUnhide.SetActive(false);

            instance.gameObject.SetActive(true);
            //if (OnWindowShow != null) OnWindowShow(instance, EventArgs.Empty);
        }

        public static void Hide() {
            if (minimapUnhide != null)  
                minimapUnhide.SetActive(true);

            instance.gameObject.SetActive(false);
            //if (OnWindowHide != null) OnWindowHide(instance, EventArgs.Empty);
        }
    }

}