using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

/*타워 생성&이동&고정&삭제 스크립트
 * SideUITK에서 특정 타워 버튼 클릭했다면
 * 현재 마우스 위치에 해당 타워 프리팹 생성
 * 마우스 이동시 타워도 같이 이동함
 * 마우스 버튼 클릭 시 
 * 해당 위치에 타워 위치 고정 이후 변경 불가
 * 타워 클릭시 SideUITK에서 타워 업그레이드 창 생성
 * 업그레이드 창에서 팔기 버튼 클릭시
 * 타워 삭제 , 판매값만큼 Money 증가
 */
public class TowerController : MonoBehaviour
{
    //RaycastHit2D hit;
    bool isDragging = false;

    public void StartDrag()
    {
        isDragging = true;
    }
    public void MyDrag()
    {
        /*
         * Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()); 
         * if (Physics.Raycast(ray, out hit, Camera.main.farClipPlane, LayerMask.GetMask("Map"))) 
         * { Vector3 nextPos = hit.point; nextPos.z = 0.5f; transform.position = Vector3.Lerp(transform.position, nextPos, t:0.2f); }
         */
        if (!isDragging) return;

        Vector3 mousePos = Mouse.current.position.ReadValue();
        float zDist = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);
        mousePos.z = zDist;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0f;   

        transform.position = Vector3.Lerp(transform.position, worldPos, 0.25f);
    }

    public void MyDrop()
    {
        //transform.Translate(translation: Vector3.down * 0.5f);

        isDragging = false;
    }
}
