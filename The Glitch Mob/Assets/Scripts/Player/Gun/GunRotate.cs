using UnityEngine;

public class GunRotate : MonoBehaviour
{
    public Player Player;

    private void Start()
    {
        Player = gameObject.GetComponent<Player>();
    }

    void Awake()
    {
        Player = GetComponent<Player>();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        GunFlip();
    }

   
    void GunFlip()
    {
        if (moveInput.x > 0.1f)
        {
            facingDirection = 1;
        }
        else if (moveInput.x < -0.1f)
        {
            facingDirection = -1;
        }

        transform.localScale = new Vector3(facingDirection, 1, 1);
        ///
   
    }
   */
}
