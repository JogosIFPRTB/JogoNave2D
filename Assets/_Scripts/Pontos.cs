using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pontos : MonoBehaviour {

	public static int Valor; // Variavel Estatica/Global que Guardara os Pontos
	Text pontoAtual;
	private void Start() {
		pontoAtual = GetComponent<Text>();
	}
	
	void Update () {

		// Atualiza o Valor dos Pontos na tela
		pontoAtual.text = "Pontos : " + Valor.ToString();
	}
}
