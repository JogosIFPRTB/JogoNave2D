using TMPro;
using UnityEngine;

/// <summary>
/// Controlador responsável por exibir e atualizar a pontuação do jogador.
/// </summary>
public class Pontos : MonoBehaviour
{

    // Variável global que armazena os pontos do jogador
    public static int Valor;

    // Referência ao componente de texto da UI
    private TMP_Text pontoAtual;

    // Instância do próprio script para facilitar o acesso global
    public static Pontos instancia;

    /// <summary>
    /// Inicializa a referência ao componente de texto e configura a instância.
    /// </summary>
    private void Awake()
    {
        // Garante que só existe uma instância do script
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject); // Previne múltiplas instâncias
        }
    }

    private void Start()
    {
        pontoAtual = GetComponent<TMP_Text>();
        AtualizarUI();
    }

    /// <summary>
    /// Adiciona pontos ao jogador e atualiza a interface.
    /// </summary>
    /// <param name="quantidade">Quantidade de pontos a adicionar.</param>
    public void AdicionarPontos(int quantidade)
    {
        Valor += quantidade;
        AtualizarUI();
    }

    /// <summary>
    /// Atualiza o texto da interface com o valor atual dos pontos.
    /// </summary>
    private void AtualizarUI()
    {
        pontoAtual.text = $"Pontos: {Valor}";
    }

    /// <summary>
    /// Reseta a pontuação para zero e atualiza a interface.
    /// </summary>
    public void ResetarPontos()
    {
        Valor = 0;
        AtualizarUI();
    }
}
