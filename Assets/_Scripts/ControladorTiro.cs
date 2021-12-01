using UnityEngine;
using System.Collections;

public class ControladorTiro : Comportamentos {

	public GameObject explosao;

	void Update () {
		// Recebe a posicao do objeto/tiro;
		posicao = transform.position;

		// Verifica se o objeto saiu da tela e o destroi
		if (posicao.y < LimiteTelaMin ().y || posicao.y > LimiteTelaMax().y)
						Destroy (gameObject);

		// Informa a posiçao para o objeto calculado pela funçao Mover
		transform.position = Mover (posicao);	
	}
}
