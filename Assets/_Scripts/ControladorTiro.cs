using UnityEngine;

/// <summary>
/// Controlador responsável pelo movimento e ciclo de vida dos tiros no jogo.
/// </summary>
public class ControladorTiro : Comportamentos
{

    // Prefab da explosão (opcional, caso o tiro gere um efeito ao ser destruído)
    public GameObject explosao;

    /// <summary>
    /// Método chamado a cada frame. Move o tiro e verifica se ele saiu da tela para destruí-lo.
    /// </summary>
    void Update()
    {
        // Atualiza a variável 'posicao' para evitar múltiplas chamadas a transform.position.
        Vector2 posicao = transform.position;

        // Verifica se o tiro saiu da tela (parte superior ou inferior) e o destrói.
        if (posicao.y <= LimiteTelaMin().y || posicao.y >= LimiteTelaMax().y)
        {
            DestruirTiro();
            return; // Retorna imediatamente para evitar execução desnecessária do código abaixo.
        }

        // Move o tiro com base na direção e velocidade
        transform.position = Mover(posicao);
    }

    /// <summary>
    /// Destroi o tiro e cria um efeito de explosão, se disponível.
    /// </summary>
    private void DestruirTiro()
    {
        // Se houver um prefab de explosão associado, instancia na posição atual
        if (explosao != null)
        {
            Instantiate(explosao, transform.position, Quaternion.identity);
        }

        // Destroi o objeto tiro
        Destroy(gameObject);
    }
}
