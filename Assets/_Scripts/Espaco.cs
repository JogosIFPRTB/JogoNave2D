using UnityEngine;

/// <summary>
/// Controlador responsável pelo efeito de rolagem do fundo espacial.
/// </summary>
public class Espaco : MonoBehaviour
{

    // Velocidade da rolagem do fundo (ajustável no Inspector do Unity)
    public float scrollSpeed = -0.5f;

    // Referência ao material do objeto para evitar chamadas repetidas
    private Material material;

    /// <summary>
    /// Método chamado ao iniciar o objeto. Obtém a referência do material.
    /// </summary>
    void Start()
    {
        // Obtém e armazena o material do objeto para otimizar as chamadas no Update()
        material = GetComponent<Renderer>().material;
    }

    /// <summary>
    /// Método chamado a cada frame. Atualiza o offset da textura para criar o efeito de movimento.
    /// </summary>
    void Update()
    {
        // Calcula o deslocamento da textura baseado no tempo e na velocidade
        float offset = Time.time * scrollSpeed;

        // Atualiza o offset da textura para criar a ilusão de movimento
        material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
