?»¿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Player : MonoBehaviour
{
    // Spaceshipã³ã³ãã?¼ãã³ã?
    Spaceship spaceship;

    public float speed = 0;

    Vector3 cashPosition;

    private Vector3 playerPos;
    private Vector3 mousePos;

    public AudioClip ShotSound;
    public AudioClip ItemAcquisition;

    //ãã¯ã¼ã¢ã?ãboolé¢æ°

    public bool PU2;
    public bool PU3;
    public bool PU4;
    public bool PU5;
    // Start is called before the first frame update
    // Startã¡ã½ã?ããã³ã«ã¼ãã³ã¨ãã¦å¼ã³åºã?
    IEnumerator Start()
    {
        // Spaceshipã³ã³ãã?¼ãã³ããåå¾?
        spaceship = GetComponent<Spaceship>();
        while (true)
        {
            // å¼¾ãã?ã¬ã¤ã¤ã¼ã¨åãä½ç½®/è§åº¦ã§ä½æ??
            spaceship.Shot(transform);
            if(PU2 == true)
            {
                spaceship.ShotPU(transform, PU2, PU3, PU4, PU5);
            }

            //,PU1,PU2,PU3,PU4

            // ã·ã§ã?ãé³ãé³´ãã
            //GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().PlayOneShot(ShotSound);

            // shotDelayç§å¾?ã¤
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        //ç»é¢å¤å¤å®?
        if (!GetComponent<SpriteRenderer>().isVisible)
        {
            Debug.Log("ç»é¢å¤?");
        }

        // ã¨ã?ã£ã¿ãå®æ©ã§å¦ç?ãå??ãã

        if (Application.isEditor)
        {
            // ã¨ã?ã£ã¿ã§å®è¡ä¸­
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("ã¯ãªã?ã¯ããç¬é?");
                /*Vector3 position = Input.mousePosition;
                iTween.MoveTo(this.gameObject, iTween.Hash("x", position.x, "y", position.y, "time", 1.0f));*/

                //playerPos = this.transform.position;
                //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                Move();
            }

            if (Input.GetMouseButtonUp(0))
            {
                playerPos = Vector3.zero;
                mousePos = Vector3.zero;
                Debug.Log("é¢ããç¬é?");     
            }

            if (Input.GetMouseButton(0))
            {
                /*Vector3 position = Input.mousePosition;
                iTween.MoveTo(this.gameObject, iTween.Hash("x", position.x, "y", position.y, "time", 1.0f));*/
                Debug.Log("ã¯ãªã?ã¯ãã£ã±ãªã?");
                
                //Vector3 prePos = this.transform.position;
                Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

                Move();

                //ã¿ã?ãå¯¾å¿ããã¤ã¹åãã?1æ¬ç®ã®æ?ã«ã®ã¿åå¿?
                if (Input.touchSupported)
                {
                    diff = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position) - mousePos;
                }

                diff.z = 0.0f;
                //this.transform.position = playerPos + diff;
                this.transform.position = Vector3.MoveTowards(transform.position, playerPos + diff, speed);
                
               
            }
            
        }
        else
        {
            // å®æ©ã§å®è¡ä¸­
            // ã¿ã?ãããã¦ã?ãããã§ã?ã¯
            if (Input.touchCount > 0)
            {
                // ã¿ã?ãæå ±ã®åå¾?
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    Debug.Log("æ¼ããç¬é?");
                }

                if (touch.phase == TouchPhase.Ended)
                {
                    Debug.Log("é¢ããç¬é?");
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    Debug.Log("æ¼ãã£ã±ãªã?");
                }
            }
        }

        Move();
    }

    void Move()
    {
        // ç»é¢å·¦ä¸ã?®ã¯ã¼ã«ãåº§æ¨ããã¥ã¼ãã?¼ãããåå¾?
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.11f));

        // ç»é¢å³ä¸ã?®ã¯ã¼ã«ãåº§æ¨ããã¥ã¼ãã?¼ãããåå¾?
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 0.8f));

        // ãã¬ã¤ã¤ã¼ã®åº§æ¨ãåå¾?
        Vector2 pos = transform.position;

        Vector3 prePos = this.transform.position;
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - mousePos;

        // ãã¬ã¤ã¤ã¼ã®ä½ç½®ãç»é¢å?ã«åã¾ããã?ã«å¶éãããã?
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        // å¶éããããå¤ãã?ã¬ã¤ã¤ã¼ã®ä½ç½®ã¨ãã
        transform.position = pos;
    }

    public void OnMouseDrag()
    {
        Vector3 objectPointInScreen = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 mousePointInScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objectPointInScreen.z);
        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);

        //mousePointInWorld.z = this.transform.position.z;
        mousePointInWorld.z = 0;

        cashPosition = mousePointInWorld;
        this.transform.position = new Vector3(cashPosition.x, cashPosition.y, cashPosition.z);
    }

    public void OnDrag(PointerEventData data)
    {
        Vector3 TargetPos = Camera.main.ScreenToWorldPoint(data.position);
        TargetPos.z = 0;
        transform.position = TargetPos;
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // ã¬ã¤ã¤ã¼åãåå¾?
        string layerName = LayerMask.LayerToName(col.gameObject.layer);

        // ã¬ã¤ã¤ã¼åãBullet (Enemy)ã®æã?¯å¼¾ãåé¤
        if (layerName == "Bullet(Enemy)")
        {
            // å¼¾ã®åé¤
            Destroy(col.gameObject);
        }

        // ã¬ã¤ã¤ã¼åãBullet (Enemy)ã¾ãã?¯Enemyã®å ´åã?¯ç?çº
        if (layerName == "Bullet(Enemy)" || layerName == "Enemy")
        {
            // ç?çºãã
            spaceship.Explosion();

            // ãã¬ã¤ã¤ã¼ãåé¤
            Destroy(gameObject);
        }

        if(layerName == "Item")
        {
            GetComponent<AudioSource>().PlayOneShot(ItemAcquisition);
            //Debug.Log("iiiiiiiii");
            //Destroy(col.gameObject);
        }
    }

}

