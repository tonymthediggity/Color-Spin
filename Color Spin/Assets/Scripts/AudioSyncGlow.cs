using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncGlow : AudioSyncer
{


    public float beatScale;
    public float restScale;

    public Light thisLight;

    // Start is called before the first frame update
    void Awake()
    {
        thisLight = this.gameObject.GetComponent<Light>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        float randomScale = Random.Range(1, 10);
        if (m_isBeat) return;
        thisLight.range = Mathf.Lerp(thisLight.range, restScale, restSmoothTime * Time.deltaTime);
    }

    public override void OnBeat()
    {
        base.OnBeat();

        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
    }

    private IEnumerator MoveToScale(float _target)
    {
        float _curr = thisLight.range;
        float _initial = _curr;
        float _timer = 0;
        while (_curr != _target)
        {
            _curr = Mathf.Lerp(_initial, _target, _timer / timeToBeat);
               // Vector3.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += Time.deltaTime;

            thisLight.range = _curr;

            yield return null;
        }
        m_isBeat = false;
    }


}
