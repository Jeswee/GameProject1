using UnityEngine;

public class randomAnimationID : MonoBehaviour
{

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TriggerRandomAnimation()
    {
        int randomID = Random.Range(1, 3);
        animator.SetInteger("randomAnimID", randomID);
        Debug.Log("I chose:" + randomID);
    }
}
