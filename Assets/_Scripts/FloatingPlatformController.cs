// Source Name: Floating Platform Controller
// Student Name: Tran Thien Phu
// Student ID: 101160213
// Program Description: Control Floating Platform


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class FloatingPlatformController : MonoBehaviour
{
    private Transform originalTransform;
    float originalWidth = 0.0f;

    public AudioSource audioSource;
    public AudioClip audioClipShrink;
    public AudioClip audioClipExpand;

    void Awake()
    {
        originalTransform = transform;
        originalWidth = transform.localScale.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        //originalTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveUpAndDown(1.0f));
    }

    public IEnumerator MoveUpAndDown(float time)
    {
        if (originalTransform.position.y < -4.30f)
        {
            transform.position = transform.position + new Vector3(0.0f,0.1f,0.0f);
        }
        else
        {
            if (transform.position.y < originalTransform.position.y)
            {
                transform.position = transform.position + new Vector3(0.0f, 0.1f, 0.0f);
            }
            else
            {
                transform.position = transform.position - new Vector3(0.0f, 0.1f, 0.0f);
            }
        }
        yield return new WaitForSeconds(time);
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        StartCoroutine(Shrink(0.5f));
    }

    private void OnCollisionExit2D (Collision2D other)
    {
        StartCoroutine(Expand(2.0f));
    }

    public IEnumerator Shrink(float time)
    {
        yield return new WaitForSeconds(time);
        audioSource.clip = audioClipShrink;
        audioSource.Play();
        transform.localScale = transform.localScale - new Vector3(0.1f, 0.0f, 0.0f);
    }

    public IEnumerator Expand(float time)
    {
        if (transform.localScale.x < originalWidth)
        {
            yield return new WaitForSeconds(time);
            audioSource.clip = audioClipExpand;
            audioSource.Play();
            transform.localScale = transform.localScale + new Vector3(0.1f, 0.0f, 0.0f);
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5.0f);  
    }
}
