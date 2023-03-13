using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StageController stageController;
    private Movement2D movement;
    private Rigidbody2D rigidBody2D;
    private void Awake()
    {
        movement = GetComponent<Movement2D>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (stageController.IsGameOver == true) return;
        // x�� �̵�
        movement.MoveToX();

        // y�� �̵� (���콺 ���� ��ư�� ������ ���� ��)
        if( Input.GetMouseButton(0) )
        {
            movement.MoveToY();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag.Equals("Item") )
        {
            stageController.IncreaseScore(1);

            // ������ ������Ʈ ����
            Destroy(collision.gameObject);
        }
        else if ( collision.tag.Equals("Obstacle") )
        {
            Destroy(rigidBody2D);
            stageController.GameOver();
        }
    }
}
