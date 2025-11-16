using UnityEngine;

public class FakeStopMotion : MonoBehaviour     //https://discussions.unity.com/t/fake-stop-motion-3d-animation-without-blending-between-frames/597610/10
{
    //PROBLEM:
        //JE NACH BILDSCHIRMGRÖßE ÄNDERT SICH LÄNGE VON ANIMATIONSCLIPS --> sorgt dafür, dass z.B. Slato nicht mehr geschafft wird

    Animator animator;
    // Use this for initialization
    void Awake () {
        animator = GetComponent<Animator>();
    }

    bool skipani = true;
    float timet = 0;
    public float frameTime = 0.125f;
    public float frameSpeed = 2;
    internal void updateAni() {
      
    }
    void FixedUpdate () {
        if (skipani) {
            //frameTime = 1 / 6f;
            //frameSpeed = 8;
            timet += Time.fixedDeltaTime;
            if (timet > frameTime) {
                timet -= frameTime;
                animator.speed = frameSpeed;
            } else {
                animator.speed = 0;
            }
        }
    }
}
