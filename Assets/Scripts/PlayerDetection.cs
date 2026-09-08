using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDetection : MonoBehaviour
{
    [SerializeField] Transform noZone;
    [SerializeField] SpriteRenderer noZoneSpriteRenderer;
    [SerializeField] Transform finishZone;
    [SerializeField] SpriteRenderer finishZoneSpriteRenderer;
    [SerializeField] GameObject youWinPanel;

    [SerializeField] float warningProximity = 2;
    [SerializeField] float shakeAmount = 0.1f;

    private Vector2 noZoneOriginalPosition;
    
    void Start()
    {
        noZoneOriginalPosition = noZone.position;
    }

    void Update()
    {
        NoZoneDetection();
        FinishZoneDetection();
    }

    private void NoZoneDetection()
    {
        float noZoneDistance = (noZone.position - transform.position).magnitude;

        if (noZoneDistance <= warningProximity)
        {
            Debug.Log("Warning No Zone");
            noZoneSpriteRenderer.color = Color.red;

            float x = Random.Range(-shakeAmount, shakeAmount);
            float y = Random.Range(-shakeAmount, shakeAmount);

            noZone.localPosition = noZoneOriginalPosition + new Vector2(x, y);

            if (noZoneDistance <= 2)
            {
                Debug.Log("Scene Restart");
                SceneManager.LoadScene("Gameplay");
            }

        }else
        {
            noZoneSpriteRenderer.color = Color.white;
            noZone.position = noZoneOriginalPosition;
        }
    }

    private void FinishZoneDetection()
    {   
        float finishZoneDistance = (finishZone.position - transform.position).magnitude;

        if (finishZoneDistance <= warningProximity)
        {
            finishZoneSpriteRenderer.color = Color.green;

            if (finishZoneDistance <= 2.5f)
            {   
                youWinPanel.SetActive(true);
                Debug.Log("You Win!");
            }
        }
        else
        {   
            finishZoneSpriteRenderer.color = Color.white;
            youWinPanel.SetActive(false);
        }
    }
}
