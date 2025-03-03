using UnityEngine;

/// <summary>
/// Controlador da nave do jogador. Responsável por capturar entradas, movimentar a nave e gerenciar tiros.
/// </summary>
public class ControladorNave : Comportamentos
{

    // Prefabs para tiro e explosão (associados no Inspector do Unity)
    public GameObject tiro, explosao;

    private void Start()
    {
        
    }

    /// <summary>
    /// Método chamado a cada frame. Gerencia a movimentação e disparo do jogador.
    /// </summary>
    void Update()
    {
        // Captura a entrada do jogador no teclado (setas ou WASD)
        direcao = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Calcula a nova posição com base na direção e velocidade
        Vector2 novaPosicao = Mover(transform.position);

        // Mantém a nave dentro dos limites da tela
        transform.position = LimitarTela(novaPosicao);

        // Verifica se o jogador pressionou o botão de tiro (configurado no Unity como "Fire1")
        if (Input.GetButtonDown("Fire1"))
        {
            // Cria um tiro na posição da nave, sem rotação
            Instantiate(tiro, novaPosicao, Quaternion.identity);
        }
    }

    /// <summary>
    /// Detecta colisões com outros objetos no jogo.
    /// </summary>
    /// <param name="colidiu">O objeto com o qual houve colisão.</param>
    void OnTriggerEnter2D(Collider2D colidiu)
    {
        // Verifica se a colisão foi com um inimigo
        if (colidiu.CompareTag("Inimigo"))
        {
            // Cria uma explosão na posição da nave
            Instantiate(explosao, transform.position, Quaternion.identity);

            // Reduz a vida do jogador
            Vida.instancia.PerderVida();
        }
    }
}
