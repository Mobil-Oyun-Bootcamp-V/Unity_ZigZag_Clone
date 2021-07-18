using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _gemParticle, _begining, _ending;
    [SerializeField] private TextMeshProUGUI _txtScore, _txtLastScore, _txtHScore, _txtGemAmount;
    [SerializeField] private Material _mTile;
    private bool isGameOver = false;

    void Awake()
    {
        isGameOver = false;
    }
    void FixedUpdate()
    {
        BallMovement.MoveWithTap(transform, isGameOver);
        _txtScore.text = Score.GetScore().ToString();
        _txtLastScore.text = Score.GetScore().ToString();
        _txtHScore.text = Score.GetHScore().ToString();
        if (transform.position != new Vector3(0, 2.5f, 0))
            _begining.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Gem")
        {
            Destroy(other.gameObject);
            Instantiate(_gemParticle, transform.position, Quaternion.identity);
            Score.ReceiptGem();
        }
    }

    void OnTriggerExit(Collider other)
    {
        Tile tile = other.GetComponent<Tile>();
        if (tile)
        {
            RaycastHit rh;
            Ray ray = new Ray(transform.position, Vector3.down);
            if (!Physics.Raycast(ray, out rh))
            {
                isGameOver = true;
                _ending.SetActive(true);
            }
        }
    }
}
