using UnityEngine;
using System.Collections;

public class Espaco : MonoBehaviour {

	public float scrollSpeed = -0.5F; // Variave de Velocidade do Scroll

	void Update() {
		// Calculando a troca do offset baseado no tempo
		float offset = Time.time * scrollSpeed;
		//Atualiza o Offset da textura para dar a impressao de movimento
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, offset));
	}
}
