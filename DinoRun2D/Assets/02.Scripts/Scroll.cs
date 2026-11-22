using UnityEngine;
using UnityEngine.UIElements;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = 2.0f; // x축의 움직이는 속도
    private Renderer quadRenderer; //Renderer 타입의 변서

    public bool isCloud; //구름인지 아닌지 판단하기 위한 bool 타입의 데이터, 구림이면 true, 아니면 false
    public float cloudScrollSpeedX = 0.5f; // 구름이 움직이는 속도

    void Start()
    {
        quadRenderer = GetComponent<Renderer>(); //Renderer 컴포넌트를 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        //if (isCloud.Equals(true)) //만약 구름이면
        //    transform.position += Vector3.left * cloudScrollSpeedX * Time.deltaTime;
        //{
        //    if (transform.position.x >= -11)
        //    {
        //        transform.position = new Vector3(11, Random.Range(0f, 4f), 0);
        //    }

        //    //}
        //    else
        //{

        gameObject.transform.position += new Vector3(gameObject.transform.position.x - cloudScrollSpeedX * Time.deltaTime,
            gameObject.transform.position.y, gameObject.transform.position.z);
        if (gameObject.transform.position.x <= -11)
        {
            gameObject.transform.position = new Vector3(11, Random.Range(0f, 4f), 0);// 이 게임 오브젝트는 - =11, 랜덤값 y가 1에서 4 사이, z = 0으로 이동
        }
        else
        {
            float offsetX = Time.time * scrollSpeedX; //시간에 따른 x축의 offset 값 계산
                                                      // Material의 메인 텍스처의 offset을 조정
            quadRenderer.material.mainTextureOffset = new Vector2(offsetX, 0f);
        }

        //            // 시간에 따라서 Offset 값을 증가시키도록 계산
        //            float offsetX = Time.time * scrollSpeedX; //시간에 따른 x축의 offset 값 계산

        //            // Material의 메인 텍스처의 offset을 조정
        //            quadRenderer.material.mainTextureOffset = new Vector2(offsetX, 0f);
        //        }
        //    }
        //}
    }
}