# 🚀 Space Shooter - Unity 6

![Unity](https://img.shields.io/badge/Unity-6.0-blue?style=for-the-badge)

Um jogo **Space Shooter 2D** desenvolvido no **Unity 6**, com movimentação de nave, tiros, inimigos e sistema de pontuação.  
Este projeto serve como base de aprendizado para **C# e desenvolvimento de jogos no Unity**.

---

## 📌 Sobre o Projeto
O jogo consiste em uma nave espacial que deve destruir inimigos enquanto evita colisões.  
A pontuação aumenta conforme o jogador acerta inimigos, e o jogo termina quando as vidas acabam.

### 🛠 **Principais Conceitos Utilizados**
- **Movimentação da nave** com controles do jogador.
- **Disparo de projéteis** e colisões com inimigos.
- **Gerenciamento de vida e pontuação** com variáveis `static`.
- **Uso de `Coroutine` (`IEnumerator`)** para ações repetitivas (ex: tiros inimigos).
- **Manipulação de UI** com `TextMeshPro` para exibição de vida, pontos e mensagens.
- **Gerenciamento de cenas** e reinício do jogo.
- **Otimização** eliminando `Update()` sempre que possível.

---

## 🎮 Funcionalidades
✅ **Movimentação livre da nave** dentro dos limites da tela.  
✅ **Tiros do jogador e dos inimigos** com colisão e destruição.  
✅ **Sistema de vida e pontuação** com exibição na UI.  
✅ **Game Over** com mensagem no centro da tela e reinício ao pressionar uma tecla.  
✅ **Inimigos se movem automaticamente** e reaparecem na parte superior da tela.  
✅ **Código modular e otimizado**, sem `Update()` desnecessário.  

---

## 📂 Estrutura do Projeto
📦 Space Shooter Unity 6 
```bash
├── 📂 Assets │ 
├── 📂 Scripts │ 
│ ├── Comportamentos.cs # Classe base para movimentação e limites de tela │ 
│ ├── ControladorNave.cs # Controle da nave do jogador │ 
│ ├── ControladorInimigo.cs # Comportamento dos inimigos │ 
│ ├── ControladorTiro.cs # Movimento e destruição dos tiros │ 
│ ├── Espaco.cs # Rolagem do fundo do jogo │ 
│ ├── Vida.cs # Sistema de vidas e reinício do jogo │ 
│ ├── Pontos.cs # Gerenciamento da pontuação │ 
├── 📂 Sprites # Imagens e animações do jogo │ 
├── 📂 UI # Elementos de interface gráfica │ 
├── 📂 Prefabs # Modelos reutilizáveis de inimigos, tiros, etc. │ 
├── 📂 Scenes # Cenas do jogo │ 
├── 📂 Sounds # Efeitos sonoros │ 
├── 📂 Materials # Materiais para gráficos e efeitos visuais 
│── 📜 README.md # Documentação do projeto
```

---

## 🔧 Pré-requisitos
Antes de iniciar, você precisará ter instalado:
- **[Unity 6](https://unity.com/)** (ou versão compatível)
- **[Visual Studio](https://visualstudio.microsoft.com/)** (ou outro editor de código)
- **Pacote TextMeshPro** (caso use na UI)

---

## 🚀 Instalação e Execução

### **1️⃣ Clonar o repositório**
```bash
git clone https://github.com/seu-usuario/space-shooter-unity6.git
```

---

### **2️⃣ Abrir no Unity**
Abra o Unity Hub.
Clique em Open e selecione a pasta do projeto.
Aguarde a importação dos arquivos.

---

### **3️⃣ Executar o Jogo**
- No Unity, vá até File → Build & Run ou pressione Play no Editor.
- Teste a nave, os tiros e a mecânica do jogo.

---

### **🎯 Como Jogar**
- 🎮 **Movimentação:** Use as setas do teclado ou WASD.
- 🎯 **Atirar:** Pressione Ctrl ou clique com o botão esquerdo do mouse.
- 💀 **Game Over:** Se a vida chegar a 0, o jogo pausa e exibe uma mensagem. Pressione qualquer tecla para reiniciar.

---

