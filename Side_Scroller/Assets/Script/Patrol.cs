using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform chara;
    public Transform PatrolA;
    public Transform PatrolB;

    [Header("Animation")]
    private Animator Animation;
    private string Marche = "Marche";

    public float dir = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() // Fait patrouiller l"ennemi entre les deux points de patrouilles
    {
        

        if (Vector2.Distance(chara.position, PatrolA.position) < 0.1f)
        {
           dir = 1f;
        }
        else if (Vector2.Distance(chara.position, PatrolB.position) < 0.1f)
        {
            dir = -1f;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        Animation.SetBool(Marche, true);

        chara.position += new Vector3(1 * Time.deltaTime * dir, 0, 0);
    }
}
