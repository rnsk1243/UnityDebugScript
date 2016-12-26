using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoCube : MonoBehaviour {

    // 디버깅 정보 표출 여부
    public bool DrawGizmos = true;

    // 기즈모를 그리도록 호출한다. 이 이벤트를 이용하면 항상 그리게 된다.
    // 선택된 오브젝트에만 기즈모를 그리도록 하려면 OnDrawGizmosSelected를 이용한다.
    void OnDrawGizmos()
    {
        if (!DrawGizmos) return;

        // 기즈모 색상
        Gizmos.color = Color.blue;

        // 전면 벡터를 그려 오브젝트가 향하는 방향을 보여준다.
        Gizmos.DrawRay(transform.position, transform.forward.normalized * 4.0f);

        // 육면체의 반경을 그림
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4.0f);
        // 기즈모의 색을 흰색으로
        Gizmos.color = Color.white;
    }
}
