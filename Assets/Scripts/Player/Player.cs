using System.Collections;
using System.Collections.Generic;
using UISETUP;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("KEYS")]
    public string keyStr;



    public UISetup ui;
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

    private void Awake()
    {
        ui = GameObject.FindObjectOfType<UISetup>();
    }
    private void Start()
    {
        m_decrese=GameObject.FindObjectOfType<Decrese>();
        m_posX=transform.position.x;
        m_animator = GetComponent<Animator>();
        m_spriteRenderer = GetComponent<SpriteRenderer>();
        m_scriptAtack = GetComponent<Atack>();
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
            localLapide = GameObject.FindGameObjectWithTag("L2").transform;
            ChangeCutPositive();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            localLapide = GameObject.FindGameObjectWithTag("L1").transform;
            ChangeCutNegative();  
        } 
    }

    private void LateUpdate()
    {
        //ui.Time(m_scriptAtack);
        //ui.Timer(m_scriptAtack);
        ui.Timer(m_scriptAtack);
        
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
            ui.AddPoint();
            ui.AddEnergy();
            CutTreeAnimation();
        }
    }

     
    private void CutTreeAnimation()
    {
        if (!m_scriptAtack.isLineVerticalCut)
        {
            obj = GetObj();

            if (obj != null)
            {
                CutTree();
            }

        }
        else
        {
            Dead();
            obj = GetObj();
            if(obj!=null)
                CutTree();


            InstantiarLapide();

            GameOver();
        }
    }

    public void InstantiarLapide()
    {
        Instantiate(lapide, localLapide.position, Quaternion.identity);
    }

    #region MUDANDO A POS DO CORTE
    public void ChangeCutPositive()
    {
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

    public void Dead()
    {
        ui.panel.SetActive(true);
        ui.SetInfor();
        InstantiarLapide();
        gameObject.SetActive(false);
        GetComponent<Player>().enabled = false;
        GetComponent<Atack>().enabled = false;
    }

    private void GameOver()
    {
        ui.ResetPoint();
    }
}
