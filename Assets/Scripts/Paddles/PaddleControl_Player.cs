using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl_Player : MonoBehaviour
{
    public float speed = 5f;
    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;
   

    void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SaveController.Instance.colorPlayer;
        else
            spriteRenderer.color = SaveController.Instance.colorEnemy;
    }


    void Update()
    {

        float moveInput = Input.GetAxis(movementAxisName); // Captura da entrada vertical (seta para cima, seta para baixo, teclas W e S)


        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime; // Calcula a nova posição da raquete baseada na entrada e na velocidade


        newPosition.y = Mathf.Clamp(newPosition.y/*define que o limite está em y*/, -4.5f, 4.5f/*valores de limite que newposition.y deve respeitar*/); // Limita a posição vertical da raquete para que ela não saia da tela
                        

        transform.position = newPosition; // Atualiza a posição da raquete e retorna para as outras funções
    }



}
