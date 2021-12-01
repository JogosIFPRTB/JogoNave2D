using UnityEngine;
using System.Collections;

public class ControladorInimigo : Comportamentos {

	public GameObject tiro, explosao; // Variaveis/Ponteiros para objetos do jogo 
	public float tempoTiro; // tempo entre os tiros do inimigo

	void Start()
	{
		StartCoroutine("Tiro"); // Inicia a Coroutine de tiros do inimigo
	}
	
	void Update () {
		// Recebe a posicao do objeto/inimigo;
		posicao = transform.position;

		// Verifica se o objeto esta colidindo com as laterais da tela e inverte seu movimento
		if (posicao.x < LimiteTelaMin ().x)
			direcao.x = 1;
		else if (posicao.x > LimiteTelaMax ().x)
			direcao.x = -1;

		// Verifica se o objeto/inimigo saiu da tela pela parte inferior e move ela para cima
		if (posicao.y < LimiteTelaMin ().y)
			posicao = ResetarPosicao ();

		// Informa a posiçao para o objeto rodando a funçao Mover
		transform.position = Mover (posicao);

	}

	IEnumerator Tiro()
	{
		// Instanciando o tiro na posicao do inimigo e sem rotaçao
		Instantiate(tiro, posicao, Quaternion.identity);
		// Aguardo pelo tempo em segundos informado na variavel tempoTiro antes de executar a proxima linha
		yield return new WaitForSeconds(tempoTiro);
		// Inicia novamente a Coroutine de tiros do inimigo
		StartCoroutine("Tiro");
	}

	// Verifica se algum objeto colidiu e guarda a informaçao dele na variavel colidiu
	void OnTriggerEnter2D(Collider2D colidiu) {
		// Verifica se a colisao foi com o objeto com a Tag "TiroPlayer";
		if (colidiu.CompareTag ("TiroPlayer")) {
			// Instanciando a explosao na posicao do inimigo e sem rotaçao
			Instantiate(explosao, posicao, Quaternion.identity);
			// Retorna ma posiçao do inimigo acima da tela e um valor de X randomico dentro do tamanho da tela
			transform.position = ResetarPosicao ();
			// Destroi o tiro que colidiu com o inimigo
			Destroy(colidiu.gameObject);
			// Soma 10 pontos para o jogador
			Pontos.Valor += 10;
		}
	}
}
