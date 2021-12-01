using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vida : MonoBehaviour {

	public static int Valor = 3; // Variavel Estatica/Global que Guardara a Vida da Nave;
	Text vidaAtual;

	private void Start() {
		vidaAtual = GetComponent<Text>();
	}
	
	void Update () {

		// Atualiza o Valor da Vida na tela
		vidaAtual.text = "Vida : " + Valor.ToString();

		// Verifica se a vida do jogador acabou e ppausa o jogo
		if (Valor <= 0) {
			Valor = 0;
			
			// pausa o jogo
			Time.timeScale = 0;
		}

		// Quando o jogo estiver pausado e o jogador apertar qualquer tecla reinicia o jogo e os valores das variaveis
		if (Time.timeScale == 0 && Input.anyKeyDown) {
			Valor = 3;
			Pontos.Valor = 0;
			Time.timeScale = 1;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
