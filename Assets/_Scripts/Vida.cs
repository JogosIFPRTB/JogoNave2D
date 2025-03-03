using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

/// <summary>
/// Gerencia o sistema de vida do jogador, exibindo o valor na interface e reiniciando o jogo quando necessário.
/// </summary>
public class Vida : MonoBehaviour
{

    // Vida atual do jogador (variável global)
    public static int Valor = 3;

    // Referência ao componente de texto da UI
    private TMP_Text vidaAtual;

    // Referência ao texto da mensagem de Game Over
    public TextMeshProUGUI mensagemGameOver; 

    // Instância do próprio script para facilitar o acesso global
    public static Vida instancia;

    // Referência ao controlador da nave para desativar os controles ao pausar o jogo
    private ControladorNave controladorNave;

    /// <summary>
    /// Configura a instância única e obtém a referência ao componente de texto da UI.
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
            Destroy(gameObject);
            return;
        }

        // Obtém a referência ao componente de texto da UI
        vidaAtual = GetComponent<TMP_Text>();

        // Busca automaticamente o script do jogador (ControladorNave)
        controladorNave = FindFirstObjectByType<ControladorNave>();

        // Certifica-se de que a mensagem de Game Over esteja oculta no início
        if (mensagemGameOver != null)
        {
            mensagemGameOver.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        AtualizarUI();
    }

    /// <summary>
    /// Reduz a vida do jogador e verifica se o jogo deve ser encerrado.
    /// </summary>
    public void PerderVida()
    {
        Valor--;

        // Atualiza a UI da vida
        AtualizarUI();

        // Verifica se a vida chegou a zero
        if (Valor <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// Atualiza o texto da interface com o valor atual da vida.
    /// </summary>
    private void AtualizarUI()
    {
        vidaAtual.text = $"Vida: {Valor}";
    }

    /// <summary>
    /// Executa ações de fim de jogo caso a vida acabe.
    /// </summary>
    private void GameOver()
    {
        Valor = 0;
        Time.timeScale = 0; // Pausa o jogo

        // Desativa o controle do jogador para impedir movimentação e tiros
        if (controladorNave != null)
        {
            controladorNave.enabled = false;
        }

        // Ativa a mensagem de Game Over
        if (mensagemGameOver != null)
        {
            mensagemGameOver.gameObject.SetActive(true);
        }

        // Aguarda entrada do jogador para reiniciar
        StartCoroutine(AguardarReinicio());
    }

    /// <summary>
    /// Aguarda o jogador pressionar uma tecla para reiniciar o jogo.
    /// </summary>
    private IEnumerator AguardarReinicio()
    {
        while (!Input.GetKey(KeyCode.Return))
        {
            yield return null;
        }

        ReiniciarJogo();
    }

    /// <summary>
    /// Reinicia o jogo, restaurando os valores iniciais e recarregando a cena.
    /// </summary>
    private void ReiniciarJogo()
    {
        Valor = 3;
        Pontos.instancia.ResetarPontos();
        Time.timeScale = 1;

        // Reativa o controle do jogador ao reiniciar o jogo
        if (controladorNave != null)
        {
            controladorNave.enabled = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
