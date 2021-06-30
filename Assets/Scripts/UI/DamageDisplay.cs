using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    private class ActiveText
    {
        public Text UIText;
        public float maxTime;
        public float currentTime;
        public Vector3 unitPosition;

        public void MoveNext(Camera camera)
        {
            float delta = 1f - (currentTime / maxTime);
            Vector3 pos = unitPosition + new Vector3(delta, delta, 0f);
            pos = camera.WorldToScreenPoint(pos);
            pos.z = 0f;

            UIText.transform.position = pos;
        }
    }

    public static DamageDisplay Instance { get; private set; }

    [SerializeField] private Text textPrefab;

    private Camera _camera;
    private Transform _transform;
    private Queue<Text> textPool = new Queue<Text>();
    private List<ActiveText> activeText = new List<ActiveText>();

    const int POOL_SIZE = 64;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _camera = Camera.main;
        _transform = transform;

        for (int i = 0; i < POOL_SIZE; i++)
        {
            Text temp = Instantiate(textPrefab, _transform);
            temp.gameObject.SetActive(false);
            textPool.Enqueue(temp);
        }
    }

    public void AddText(int damage, Vector3 unitPos)
    {
        var t = textPool.Dequeue();
        t.text = damage.ToString();
        t.gameObject.SetActive(true);
        ActiveText at = new ActiveText() { maxTime = 1f };
        at.currentTime = at.maxTime;
        at.UIText = t;
        at.unitPosition = unitPos + Vector3.up / 2;

        at.MoveNext(_camera);

        activeText.Add(at);
    }

    private void Update()
    {
        for (int i = 0; i < activeText.Count; i++)
        {
            ActiveText at = activeText[i];
            at.currentTime -= Time.deltaTime;

            if (at.currentTime <= 0f)
            {
                at.UIText.gameObject.SetActive(false);
                textPool.Enqueue(at.UIText);
                activeText.RemoveAt(i);
                --i;
            }
            else
            {
                var color = at.UIText.color;
                color.a = at.currentTime / at.maxTime;
                at.UIText.color = color;

                at.MoveNext(_camera);
            }
        }
    }
}
