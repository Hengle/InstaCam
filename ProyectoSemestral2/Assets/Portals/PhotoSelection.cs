using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PhotoSelection : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
	
	public Animator anim;
	// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
	
	public void OnPointerEnter(PointerEventData pointerEventData){
		Debug.Log("In");
		anim.CrossFade("Show",0.25f);
	}
    
	public void OnPointerExit(PointerEventData pointerEventData){
		Debug.Log("OUT");
		anim.CrossFade("Hide",0.25f);
	}
    
   
}
