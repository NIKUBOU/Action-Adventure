using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;

    private Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        container = transform.Find("container");
        keyTemplate = container.Find("Key Template");
        keyTemplate.gameObject.SetActive(false);

    }

    private void Start()
    {
        keyHolder.onKeysChanged += KeyHolder_onKeysChanged;
    }

    private void KeyHolder_onKeysChanged (object sender, System.EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        // clean upold keys
        foreach (Transform child in container)
        {
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        }

        // Instantiate current key list
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {   
            Key.KeyType keyType = keyList[i];
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTemplate.gameObject.SetActive(true);
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(50 * i, 0);
            Image keyImage = keyTransform.Find("image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case Key.KeyType.normal: keyImage.color = Color.white;
                    break;
                case Key.KeyType.boss: keyImage.color = Color.white;
                    break;
            }
        }
        
    }
}
