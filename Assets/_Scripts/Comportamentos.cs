using UnityEngine;

/// <summary>
/// Classe base que contém métodos para movimentação e controle de limites na tela.
/// Pode ser herdada por outros scripts para facilitar a movimentação de objetos no jogo.
/// </summary>
public class Comportamentos : MonoBehaviour
{

    // Direção do movimento do objeto
    public Vector2 direcao;

    // Velocidade de movimentação do objeto (valor ajustável no Inspector)
    public float velocidade = 5f;

    // Limites da tela para restringir o movimento dos objetos
    private static Vector2 limiteMin;
    private static Vector2 limiteMax;

    // Variável de controle para evitar cálculos repetidos dos limites
    private static bool limitesDefinidos = false;

    /// <summary>
    /// Método chamado ao iniciar o objeto. Define os limites da tela se ainda não foram definidos.
    /// </summary>
    protected virtual void Awake()
    {
        DefinirLimites();
    }

    /// <summary>
    /// Define os limites da tela com base na posição da câmera principal.
    /// Isso é feito apenas uma vez para evitar cálculos desnecessários.
    /// </summary>
    private void DefinirLimites()
    {
        if (!limitesDefinidos)
        {
            limiteMin = Camera.main.ViewportToWorldPoint(Vector2.zero);  // Canto inferior esquerdo
            limiteMax = Camera.main.ViewportToWorldPoint(Vector2.one);   // Canto superior direito
            limitesDefinidos = true;
        }
    }

    /// <summary>
    /// Calcula a nova posição do objeto com base na direção e velocidade.
    /// Esse método não altera a posição diretamente, apenas retorna a nova posição calculada.
    /// </summary>
    /// <param name="posicaoAtual">A posição atual do objeto.</param>
    /// <returns>A nova posição do objeto após o movimento.</returns>
    public Vector2 Mover(Vector2 posicaoAtual)
    {
        return posicaoAtual + direcao * velocidade * Time.deltaTime;
    }

    /// <summary>
    /// Retorna o canto inferior esquerdo da tela (mínimo visível).
    /// </summary>
    public static Vector2 LimiteTelaMin() => limiteMin;

    /// <summary>
    /// Retorna o canto superior direito da tela (máximo visível).
    /// </summary>
    public static Vector2 LimiteTelaMax() => limiteMax;

    /// <summary>
    /// Mantém a posição do objeto dentro dos limites da tela.
    /// </summary>
    /// <param name="posicaoAtual">A posição do objeto antes da restrição.</param>
    /// <param name="margemInferior">Margem opcional para evitar que o objeto fique muito próximo da borda inferior.</param>
    /// <returns>A posição ajustada dentro dos limites da tela.</returns>
    public static Vector2 LimitarTela(Vector2 posicaoAtual, float margemInferior = 0.5f)
    {
        posicaoAtual.x = Mathf.Clamp(posicaoAtual.x, limiteMin.x, limiteMax.x);
        posicaoAtual.y = Mathf.Clamp(posicaoAtual.y, limiteMin.y + margemInferior, limiteMax.y);
        return posicaoAtual;
    }

    /// <summary>
    /// Retorna uma nova posição aleatória acima da tela para reposicionar um objeto (ex: inimigos).
    /// </summary>
    /// <returns>Uma posição fora da tela na parte superior, com um X aleatório dentro da tela.</returns>
    public static Vector2 ResetarPosicao()
    {
        return new Vector2(Random.Range(limiteMin.x, limiteMax.x), limiteMax.y);
    }
}
