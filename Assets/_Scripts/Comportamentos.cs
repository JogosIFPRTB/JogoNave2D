using UnityEngine;
using System.Collections;

public class Comportamentos : MonoBehaviour {

	// Definiçao de Variaveis que serao usadas pelos objetos do Jogo
	public Vector2 direcao, posicao;
	public float velocidade;

	// Calcula a posicao atual + direcao que o objeto vai tomar e 
	// multiplica pela velocidade que o objeto ira se mover e
	// multipica pelo deltatime, para o loop ser feito atravez do tempo
	public Vector2 Mover(Vector2 posicaoAtual) {

		return posicaoAtual + direcao * velocidade * Time.deltaTime;
	}

	// Retorna o menor ponto visivel(canto esquerdo inferior) da tela
	// (so funciona se a Camera estiver em Orthographic)
	public Vector2 LimiteTelaMin(){

		return Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
	}

	// Retorna o menor ponto visivel(canto direito superior) da tela
	// (so funciona se a Camera estiver em Orthographic)
	public Vector2 LimiteTelaMax(){
		
		return Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
	}

	// Limita o objeto dentro da tela
	public Vector2 LimitarTela(Vector2 posicaoAtual) {

		Vector2 Min = LimiteTelaMin ();
		Vector2 Max = LimiteTelaMax ();
		
		posicaoAtual.x = Mathf.Clamp (posicaoAtual.x, Min.x, Max.x);
		posicaoAtual.y = Mathf.Clamp (posicaoAtual.y, Min.y + 0.5f, Max.y);

		return posicaoAtual;
	}

	// Retorna uma posiaao do objeto acima da tela e um valor de X randomico dentro do tamanho da tela
	public Vector2 ResetarPosicao() {
		
		return new Vector2(Random.Range (LimiteTelaMin ().x, LimiteTelaMax ().x), LimiteTelaMax ().y);
	}
}
