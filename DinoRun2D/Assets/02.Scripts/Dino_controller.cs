using UnityEngine;
using UnityEngine.SceneManagement;

public class Dino_controller : MonoBehaviour
{
    public float jumpForce; // 얼마만큼의 힘으로 점프한건가
    public bool isGrounded; // 땅에 닿아있는지 확인하는 변수
    public bool isDown; // 아래 키 누른 상태냐?
    float jumpPorce = 300.0f;
    Rigidbody2D rigid2D;

    public Transform groundCheckPoint; // 빨간 점의 위치
    public LayerMask whatIsGround; //Ground인지 비쿄할 Layermask


    private Animator anim; // 애니메이터를 가져오기 위한 변수
    void Start()
    {
        anim = GetComponent<Animator>();
        //처음은 달리는 상태여야 합니다
        rigid2D = GetComponent<Rigidbody2D>();
        
        //지난번에 했던것을 떠올리며 처음에는 Run 상태로 새팅해보세요
        anim.SetBool("isground",true);
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.05f, whatIsGround);
            
            // Space 키를 눌렀을때 점프 애니메이션 실행

            // Space 키를 땔 때 다시 RUn 애니메이션 실행
            if (Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            //rigid2D.AddForce(Vector3.up * jumpPorce);
       
            rigid2D.linearVelocity = new Vector2(rigid2D.linearVelocity.x, jumpForce); // DIno의 가속도를 y방향으로 jumpForce 마냥 준다
        }

        
        anim.SetBool("isground", isGrounded); // isGroundede의 값에 따라 자동으로 애니메이션 세팅

    }
    void OnDrawGizmos()// 범위그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheckPoint.position, 0.2f);
    }
}
//Rigidbody: 예는 알지? 물리적 속성을 오브젝트에 부여하는거야 중력에 영향을 받게 하지

//collider: 예는 충돌 영역을 정의하는거야 물리적인 상호작용을 하기 위해 필요하지 Trigger 속성에 충돌하면 충돌 감지는 하지만 물리적 반응 없이 이벤트만 발생시켜

//physics Materials 예는 오브젝트 표면 특성 정의할때 마찰력이나 반발력을 설정 가능


//isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);
//Physics2D 함수는 유니티에서 2D환경에서 사용되는 함수로 지정된 원의 중심과 반경 내에 이쓴ㄴ 2D 콜라이더를 감지하는데 사용됩니다
    //이 함수는 주로 충돌 감지나 주변 오브젝트를 감지하는데 사용됩니다.

    //기본 모습은
    //Collider2D physics2D.OverlapCircle(Vector2 Point, float radius, int layerMask = DefaultRaycastLayers);

//매개 변수는 다음과 같습니다
//point: 원의 중심을 나타내는 Vectot2 값입니다 이는 주로 월드 좌표로 설정됩니다
//radius : 원의 반경을 나타내는 float 값입니다 이 값은 감지할 원의 크기로 결정합니다.
//LayerMask: 선택사항으로 특정 레이어의 콜라이더만 감지하려면 이 값을 설정합니다.
//기본 값은 DefaultRaycastLaters 이먀, 이는 모든 레이어를 대상으로 설정됩니다.