# 🟠 Tocapelotas - Unity

Juego 2D desarrollado en Unity donde debemos clicar las pelotas antes de que caigan a los pinchos para conseguir la máxima puntuación posible.

## 🎮 Cómo jugar
- Haz clic sobre las pelotas para destruirlas.
- Consigue puntos por cada pelota eliminada.
- Evita que las pelotas lleguen a los pinchos.
- Intenta superar tu récord de puntuación.

## 🧩 Gameplay

### Objetos principales
- Cursor
- Pelotas (Alien)
- Plataformas (Ramp)
- Pinchos (Spikes)
- Fondo

### HUD
- Contador de puntos (Score)
- Puntuación máxima (Highscore)

## 🧠 Menús y pantallas
- Menú principal (botones Play y Quit)
- Gameplay
- Game Over

## 🔁 Flujo del juego
- Menú → Gameplay
- Gameplay → Game Over
- Game Over → Menú

## ⚙️ Comportamientos principales

### 🟠 Pelotas (Alien)
- Detectan el clic del jugador.
- Se generan en posiciones aleatorias en la parte superior de la pantalla.
- Existen distintos tipos de pelotas.
- Al destruirse:
  - Emiten partículas.
  - Reproducen un sonido.
  - Aumentan la puntuación.

#### Pelotas que caen
- Afectadas por gravedad.
- Otorgan una cantidad determinada de puntos.

#### Pelotas flotantes
- Movimiento flotante.
- Otorgan una cantidad diferente de puntos.

### 🟫 Plataformas (Ramp)
- Detectan colisiones con las pelotas.
- Reproducen sonido al impactar una pelota.
- Algunas se mueven por efectos físicos.
- Ejecutan una animación de entrada al comenzar la partida.

### 🔺 Pinchos (Spikes)
- Detectan colisiones con las pelotas.
- Provocan el Game Over cuando una pelota los toca.

### 🖱️ Cursor
- Detecta los clics del jugador.
- Permite interactuar con las pelotas.

## 🔊 Audio
- Sonido al clicar una pelota (Alien)
- Sonido al clicar el fondo (Missclick)
- Sonido de colisión con plataforma (Ramp)
- Sonido de Game Over
- Música de fondo

## ✨ VFX
- Partícula de destrucción de pelota (Alien)

## 🛠️ Tecnologías
- Unity
- C#
- Física 2D
- Sistema de partículas
- Sistema de audio

## 📸 Gameplay
- Menú principal
- Pantalla de juego
- Pantalla de Game Over

## 🚀 Estado del proyecto
- ✔ Jugable
- ✔ Sistema de puntuación implementado
- ✔ Highscore persistente
- ✔ Menú principal funcional
- ✔ Sistema de audio implementado
- ✔ Efectos visuales implementados
- ✔ Completo funcionalmente para un jugador

- <img width="645" height="364" alt="Captura de pantalla 2026-06-16 115700" src="https://github.com/user-attachments/assets/39afd28d-943a-4167-ac0f-e9dc72c63c1a" />

