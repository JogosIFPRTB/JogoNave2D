using UnityEngine;
using System.Collections;

/// <summary>
/// Controlador de inimigos. Gerencia movimentação, tiros e colisões dos inimigos no jogo.
/// </summary>
public class ControladorInimigo : Comportamentos
{

    // Prefabs para tiro e explosão (configurados no Inspector do Unity)
    public GameObject tiro, explosao;

    // Tempo entre os tiros do inimigo
    public float tempoTiro = 2f;

    /// <summary>
    /// Método chamado ao iniciar o inimigo. Inicia a rotina de disparos automáticos.
    /// </summary>
    void Start()
    {
        StartCoroutine(Tiro());
    }

    /// <summary>
    /// Método chamado a cada frame. Gerencia o movimento do inimigo e reposicionamento caso saia da tela.
    /// </summary>
    void Update()
    {
        // Obtém a posição atual do inimigo
        Vector2 posicao = transform.position;

        // Verifica se o inimigo atingiu as bordas laterais da tela e inverte a direção
        if (posicao.x <= LimiteTelaMin().x)
        {
            direcao.x = 1;
        }
        else if (posicao.x >= LimiteTelaMax().x)
        {
            direcao.x = -1;
        }

        // Verifica se o inimigo saiu da tela pela parte inferior e o reposiciona no topo
        if (posicao.y <= LimiteTelaMin().y)
        {
            posicao = ResetarPosicao();
        }

        // Move o inimigo com base na direção e velocidade
        transform.position = Mover(posicao);
    }

    /// <summary>
    /// Rotina que faz o inimigo disparar tiros em intervalos regulares.
    /// </summary>
    IEnumerator Tiro()
    {
        // O loop while (true) cria um loop infinito dentro da Coroutine.
        // Isso significa que o inimigo continuará atirando enquanto o objeto existir.
        // A execução da Coroutine será pausada a cada "WaitForSeconds(tempoTiro)",
        // garantindo que os tiros sejam disparados em intervalos regulares.
        while (true)
        {
            // Instancia um tiro na posição atual do inimigo
            Instantiate(tiro, transform.position, Quaternion.identity);

            // Aguarda o tempo definido antes de disparar novamente
            yield return new WaitForSeconds(tempoTiro);
        }
    }

    /// <summary>
    /// Detecta colisões com outros objetos no jogo.
    /// </summary>
    /// <param name="colidiu">O objeto com o qual houve colisão.</param>
    void OnTriggerEnter2D(Collider2D ComQuemcColidiu)
    {
        // Verifica se a colisão foi com um tiro do jogador
        if (ComQuemcColidiu.CompareTag("TiroPlayer"))
        {
            // Cria uma explosão na posição do inimigo
            Instantiate(explosao, transform.position, Quaternion.identity);

            // Move o inimigo para uma nova posição no topo da tela
            transform.position = ResetarPosicao();

            // Destroi o tiro do jogador
            Destroy(ComQuemcColidiu.gameObject);

            // Adiciona 10 pontos ao jogador
            Pontos.instancia.AdicionarPontos(10);

        }
    }
}
