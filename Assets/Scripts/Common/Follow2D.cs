using UnityEngine;

public class Follow2D : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag;
    [SerializeField] [Range(0.5f, 7.5f)] private float movingSpeed = 1.5f;
    
    private void Update()
    {
        if (playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = playerTransform.position.x + 3,
                y = transform.position.y,
                z = playerTransform.position.z - 10,
            };

            Vector3 pos = Vector3.Lerp(transform.position, target, movingSpeed * Time.deltaTime);

            transform.position = pos;
        }
    }
    
    public void SetStart()
    {
        if (playerTransform == null)
        {
            if (playerTag == "")
            {
                playerTag = "Player";
            }
            
            playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;
        }
        movingSpeed = 1.5f * GameManager.HardMode;
        
        transform.position = new Vector3()
        {
            x = playerTransform.position.x,
            y = transform.position.y,
            z = playerTransform.position.z - 10,
        }; 
    }
    
}