using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBox : MonoBehaviour
{

    public string text;
    [Range(1f, 60f)]
    public float totalSec = 10f;

    
    private bool triggered = false;
    //public BoxCollider trigger;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI DBText = GetComponentInChildren<TextMeshProUGUI>();
        //trigger = GetComponentInChildren<BoxCollider>();
        DBText.text = text;

        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
        playerControllerScript pcScript =
            other.transform.root.GetComponent<playerControllerScript>();
        //Debug.Log("Triggered1");
        if (!triggered && pcScript != null)
        {
            triggered = true;
           // Debug.Log("triggered2");
            StartCoroutine(playAnim());
        }
        
    }

    IEnumerator playAnim()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(totalSec);
        anim.SetTrigger("End");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
