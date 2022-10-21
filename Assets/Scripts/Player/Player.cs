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
    public GameObject obj;



    [Header("Setup Circle")]
    public Transform circle;

    [Header("Força de Corte")]
    public Vector2 ForceCut;

    public float timeToDestroy;

    public bool circleRay;

    public bool wasCut;

    private Decrese m_decrese;

    public float timeToDecrese;

    private float m_isAtack;


    public GameObject lapide;
    public Transform localLapide;
    public bool side;
    private void Start()
    {
        m_decrese=GameObject.FindObjectOfType<Decrese>();
        m_posX=transform.position.x;
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_scriptAtack = GetComponent<Atack>();
        //this.enabled = false; QUANDO INICIAR O GAME
        m_spriteRenderer.flipX = true;
        m_isAtack = ForceCut.x;
    }


    private void Update()
    {
        if (circleRay != false)
            Circle();

        SetAnimationsPlayer();

        if (Input.GetKeyDown(KeyCode.A))
        {
            //localLapide.position += Vector3.left;
            localLapide = GameObject.FindGameObjectWithTag("L2").transform;
            ChangeCutPositive();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            localLapide = GameObject.FindGameObjectWithTag("L1").transform;
            ChangeCutNegative();  
        } 
    }

    private bool Circle()
    {
        return Physics2D.OverlapCircle(circle.position, radius, woods);
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
        if (!m_scriptAtack.isLineVerticalCut)//linhaUp for negativo
        {
            obj = GetObj();

            if (obj != null)
            {
                CutTree();
            }

        }
        else
        {
            //LOGICA PARA FAZER O PLAYER MORRER
            //CutTree();
            //Line Ativada, ou seja, tem galho em cima
            gameObject.SetActive(false);
            GetComponent<Player>().enabled = false;
            GetComponent<Atack>().enabled = false;
            obj = GetObj();
            if(obj!=null)
                CutTree();


            Instantiate(lapide, localLapide.position, Quaternion.identity);
            
            
            Debug.Log(m_scriptAtack.isLineVerticalCut);
        }
    }

    #region MUDANDO A POS DO CORTE
    public void ChangeCutPositive()
    {
        //if (side)
        //{
        //    localLapide.position += Vector3.left*2;
        //    side = false;
        //}

        transform.position = new Vector2(-m_posX, transform.position.y);
        m_spriteRenderer.flipX = false;
        circle.localPosition = new Vector2(1.7f, -.25f);

        do
        {
            ForceCut = new Vector2(-m_isAtack, ForceCut.y);

        } while (m_spriteRenderer.flipX);
        
    }

    private GameObject GetObj()
    {
        return Physics2D.OverlapCircle(circle.position, radius, woods).transform.gameObject;
    }

    public void ChangeCutNegative()
    {
        side = false;
        transform.position = new Vector2(m_posX, transform.position.y);
        m_spriteRenderer.flipX = true;
        circle.localPosition = new Vector2(-1.7f, -.25f);
        do
        {
            ForceCut = new Vector2(m_isAtack, ForceCut.y);

        } while (!m_spriteRenderer.flipX);

    }
    #endregion

    public void CutTree()
    {
        obj.transform.SetParent(null);
        obj.GetComponent<SpriteRenderer>().sortingOrder = 2;
        obj.GetComponent<Collider2D>().enabled = false;
        obj.GetComponent<Rigidbody2D>().AddForce(ForceCut);
        obj.GetComponent<Rigidbody2D>().gravityScale = 1;
        Invoke("Decrese",timeToDecrese);
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(circle.position, radius);
    }

    private void Decrese()
    {
        m_decrese.Decrescer();
    }
}
