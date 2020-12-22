using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingColor : MonoBehaviour
{
	private Renderer ringRend;
	public Color ringColor;
	private Color ringColorEmit;
	private float emitVal = 1f;


    void Start()
    {
		ringRend = gameObject.GetComponentInChildren<MeshRenderer>();

		ringRend.material.color = ringColor;

		ringColorEmit = ringColor * emitVal;
		ringRend.material.EnableKeyword("_EMISSION");
		ringRend.material.SetColor("_EmissionColor", ringColorEmit);
    }
		
    public void PlayerBoost()
    {
		StartCoroutine(ColorChange());
    }


	IEnumerator ColorChange(){
		ringRend.material.color = Color.red;
		ringRend.material.EnableKeyword("_EMISSION");
		ringRend.material.SetColor("_EmissionColor", Color.red);

		Debug.Log("I made it red!");
		yield return new WaitForSeconds(0.1f);
		ringRend.material.color = ringColor;

		ringRend.material.EnableKeyword("_EMISSION");
		ringRend.material.SetColor("_EmissionColor", ringColorEmit);

		}


}
