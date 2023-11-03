using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float restartLevelDelay = 1f;
    private Vector2 TargetPos;
    public float DashRange;
    public float Speed;
    private Vector2 Direction;
    private Animator Animator;

    private enum Facing {UP,DOWN,LEFT,RIGHT};
    private Facing FDir = Facing.DOWN;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TakeInput();
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Exit")
        {
            PlayerStats.playerStats.SaveRecord(PlayerStats.playerStats.points);
            Invoke("Restart", restartLevelDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(1);
    }

    private void Move()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
        if (Direction.x != 0 || Direction.y != 0)
        {
            SetAnimatorMovement(Direction);
        }
        else
        {
            Animator.SetLayerWeight(1, 0);
        }
    }

    private void TakeInput()
    {
        Direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            Direction += Vector2.up;
            FDir = Facing.UP;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction += Vector2.left;
            FDir = Facing.LEFT;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction += Vector2.down;
            FDir = Facing.DOWN;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction += Vector2.right;
            FDir = Facing.RIGHT;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TargetPos = Vector2.zero;
            if (FDir == Facing.UP)
            {
                TargetPos.y = 1;
            }
            else if (FDir == Facing.DOWN)
            {
                TargetPos.y = -1;
            }
            else if (FDir == Facing.RIGHT)
            {
                TargetPos.x = 1;
            }
            else if (FDir == Facing.LEFT)
            {
                TargetPos.x = -1;
            }
            transform.Translate(TargetPos * DashRange);
        }
    }

    private void SetAnimatorMovement(Vector2 Dir)
    {
        Animator.SetLayerWeight(1, 1);
        Animator.SetFloat("Ox", Dir.x);
        Animator.SetFloat("Oy", Dir.y);
    }
}
