using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Atack m_scriptAtack;
    [SerializeField]private float m_posX;

    private Animator m_animator;
    private SpriteRenderer m_spriteRenderer;

    public string triggerToAttack;

    public float radius;
    public LayerMask woods;
    private void Start()
    {
        m_posX=transform.position.x;
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_scriptAtack = GetComponent<Atack>();
        this.enabled = false;
    }


    private void Update()
    {
        SetAnimationsPlayer();

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector2(-m_posX, transform.position.y);
            m_spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector2(m_posX, transform.position.y);
            m_spriteRenderer.flipX = true;

        }
    }

    private void SetAnimationsPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_animator.SetTrigger(triggerToAttack);
            CutTreeAnimation();
        }
    }


    private void CutTreeAnimation()
    {
        if (!m_scriptAtack.isLineOn)//linha for negativo
        {
            bool a = Physics2D.OverlapCircle(transform.position, radius, woods);
            Debug.Log(a);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
