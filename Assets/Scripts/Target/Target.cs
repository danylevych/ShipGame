using UnityEngine;


// +=========================================+
// |                                         |
// |    This script describes the target.    |
// |                                         |
// +=========================================+

public class Target : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int speedHint;
    [SerializeField] private GameObject hintPref;
    [SerializeField] private GameObject explosionPref;

    private GameObject hint;
    private Vector3 startTargetPos;


    private void Start()
    {
        health = 100;

        // Creating a hint that rotation around the target.
        startTargetPos = gameObject.transform.position;
        hint = Instantiate(hintPref, new Vector3(0, 0, -15), Quaternion.identity);
        hint.transform.localScale = new Vector3(20f, 20f, 20f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject e = Instantiate(explosionPref, gameObject.transform.position, explosionPref.transform.rotation);

            Destroy(gameObject);
            Destroy(hint);
            Destroy(e, 0.25f);
        }
    }

    private void Update()
    {
        hint.transform.localScale = Vector3.Lerp(hint.transform.localScale, hintPref.transform.localScale, Time.deltaTime * speedHint);

        hint.transform.position = Vector3.Lerp(hint.transform.position, startTargetPos, Time.deltaTime * speedHint);

        // The target and hint rotation to the direcrion to user's view.
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.z += Camera.main.farClipPlane;

        Vector3 posToCenter = Vector3.LerpUnclamped(transform.position, cameraPos, transform.position.z / 100f);
        hint.transform.rotation = transform.rotation = Quaternion.Inverse(Quaternion.Euler(new Vector3(posToCenter.y, -posToCenter.x, 0)));
    }
}
