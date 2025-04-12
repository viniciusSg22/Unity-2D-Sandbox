using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController_2 player;
    public CameraFollow cameraFollow;
    public ParallaxBackgroundLooper parallax;
    public InputManager input;

    void Start()
    {
        StartCoroutine(InitializeGame());
    }

    IEnumerator InitializeGame()
    {
        // Desativa input e parallax inicialmente
        input.enabled = false;
        parallax.enabled = false;

        // Garante que o player seja posicionado corretamente
        player.Initialize();

        // Aguarda um frame para o player "assentar"
        yield return null;

        // Câmera segue o player
        cameraFollow.SnapToPlayer();

        // Aguarda a câmera se mover
        yield return null;

        // Agora ativa o parallax com a câmera já posicionada
        parallax.Initialize();

        // Por fim, ativa o input
        input.enabled = true;
    }
}
