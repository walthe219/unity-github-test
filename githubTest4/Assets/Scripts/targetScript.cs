using UnityEngine;

public class targetScript : MonoBehaviour
{
    public const float MAX_HP = 10f;

    private float health;

    private void Start()
    {
         health = MAX_HP;
    }

}
