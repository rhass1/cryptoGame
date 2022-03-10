using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    bool taskComplete = false;
    BoxCollider2D collider;
    float horizontalMove;
    public Animator animator;
    public GameObject head;
    public float speed = 10f;
    public float distance;
    Transform target;
    bool isMoving = true;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;
        target = FindObjectOfType<Controller>().transform;
        head.SetActive(false);
    }
    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (transform.position.x <= distance)
        {
            isMoving = false;
            if (taskComplete == false)
            {
                open();
            }
            animator.SetBool("isMove", false);
            head.SetActive(true);
            Destroy(this.gameObject, 1.3f);
        }

        void open()
        {
            taskComplete = true;
            StartCoroutine(bite());
        }

        IEnumerator bite()
        { 
            yield return new WaitForSeconds(.4f);
            collider.enabled = true;
            Debug.Log("open");
            StartCoroutine(close());
        }

        IEnumerator close()
        {
            yield return new WaitForSeconds(.22f);
            collider.enabled = false;
            Debug.Log("close");
        }
    }
}
