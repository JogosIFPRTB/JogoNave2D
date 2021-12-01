using UnityEngine;
using System.Collections;

public class ControladorNave : Comportamentos {

	public GameObject tiro, explosao; // Variaveis/Ponteiros para objetos do jogo 

	void Update () {

		// A variavel de direçao sera informada pelo Inputs "Horizontal" em X e "Vertical" em Y;
		direcao = new Vector2 (Input.GetAxisRaw ("Horizontal"),
		                       Input.GetAxisRaw ("Vertical"));

		// A varivel posicao recebera o valor calculado da funçao Mover
		posicao = Mover (transform.position);

		// O objeto/nave recebera a posiçao ja limitada na tela de acordo com a funçao LimitarTela
		transform.position = LimitarTela (posicao);
		
		// Se pressionar o botao "Fire1", pre configurado no Unity como Crtl e Clique esquerdo do Mouse
		if (Input.GetButtonDown ("Fire1"))
			// Instanciando o tiro na posicao da Nave e sem rotaçao
			Instantiate (tiro, posicao,Quaternion.identity);
	}

	// Verifica se algum objeto colidiu e guarda a informaçao dele na variavel colidiu
	void OnTriggerEnter2D(Collider2D colidiu) {
		// Verifica se a colisao foi com o objeto com a Tag "Inimigo";
		if (colidiu.CompareTag ("Inimigo")) {
			// Instanciando a explosao na posicao da Nave e sem rotaçao
			Instantiate(explosao, posicao, Quaternion.identity);
			// Subtrai um da Vida
			Vida.Valor -= 1;
		}

	}
}
