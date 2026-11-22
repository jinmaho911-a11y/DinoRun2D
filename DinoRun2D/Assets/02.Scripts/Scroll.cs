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
        if (isCloud.Equals(true)) //만약 구름이면
        {
            transform.position += Vector3.left * cloudScrollSpeedX * Time.deltaTime;
            {
                if (transform.position.x <= -11)
                {
                    transform.position = new Vector3(11, Random.Range(0f, 4f), 0);
                }

            }
        }
        else
        {
            // 시간에 따라서 Offset 값을 증가시키도록 계산
            float offsetX = Time.time * scrollSpeedX; //시간에 따른 x축의 offset 값 계산

            //Material의 메인 텍스처의 offset을 조정
            quadRenderer.material.mainTextureOffset = new Vector2(offsetX, 0f);
            //gameObject.transform.position += new Vector3(gameObject.transform.position.x - cloudScrollSpeedX * Time.deltaTime,
            //    gameObject.transform.position.y, gameObject.transform.position.z);
            //if (gameObject.transform.position.x <= -11)
            //{
            //    gameObject.transform.position = new Vector3(11, Random.Range(0f, 4f), 0);// 이 게임 오브젝트는 - =11, 랜덤값 y가 1에서 4 사이, z = 0으로 이동
            //}
            //else
            //{
            //    float offsetX = Time.time * scrollSpeedX; //시간에 따른 x축의 offset 값 계산
            //                                              // Material의 메인 텍스처의 offset을 조정
            //    quadRenderer.material.mainTextureOffset = new Vector2(offsetX, 0f);
            //}



        
        }
    }
}
//    }
//}
// 3번째 네모 Wrap Mode은 텍스쳐가 타일링 될때 경계를 어떻게 처리하는지 설정임다

//Repeat: 타일의 택스처를 반복
//Clamp 텍스처의 모서리 늘림
//Mirror 모든 정수 경계의 텍스처를 미러링하여 반복 패턴
//Mirror Once: 텍스처를 한번 미러링 한 후 모서리 픽셀에 고정합니다
//Per-axis: U 축과 V축에서 유니티가 텍스처를 래핑하는 방식을 개별적으로 제어합니다


//4번째 네모 filter Mode는 텍스처의 샘플링 방법을 결정하는 속성

//Point: 텍스처의 가장 가까운 픽셀 색상을 그대로 사용합니다 결과적을 텍스처가 확대되면 픽셀이 크게 보이며 레트로 또는 픽셀 아트 스타일에 적합
//Bilinear:인접한 4개의 픽셀 색상 혼합하여 부드러운 결과 생성 텍스처가 확대되거나 축소 될때 픽셀이 부드럽게 보임 하지만 확대시 흐릿해짐
//Trilinear : Bilinear필터링에 더해 텍스처의 여러 mipmap레벨 간에도 혼합을 수행함다 가장 부드러운 결과를 제공하며 특이 3d게임에서 텍스처의 크기가크게 변화하는 경우 유용함다

//다섯번째 네모 Max Size 는 텍스처의 최대 크기로 주로 메모리 성능에 영향을 미침

//최대 텍스처 크기:일부 플롯폼에서는 16384 x 16384일반적은 8192x8192

// 스프라이트 크기와 텍스처: 스프라이트는 텍스처의 일부로 사용되며 텍스처 아틀라스를 사용하는 경우 텍스처의 크기가 중요
//너무 큰 텍스처를 사용할시 메모리 소모가 많아짐 텍스트 압축 및 스프라이트 아틀라스 사용 ㄱㄱ 

//메모리 및 성능 최적화: 큰 크기의 스프라이트는 GPU 메모리를 많이 사용할수 있으므로 필요하지 않는 경우 
//크기를 줄이는 것이 좋음 이를 위해 Sprit Packer 또는 Texture Atlases를 사용해 여러 스프라이트를 하나의 텍스처로 결합하는 방법 또한

//6번째 네토 Compression은 텍스처 메모리 사용량을 줄이고 성능을 향상시키기 위해 사용되는 중요 기능 압축된 스프라이트는 용량이 적고 로딩 속도가 빨라지지만 품질이 낮아질수 있으므로
//적절한 설정이 필요함다

//합축 옵션 종류:
//None: 압축 사용 ㄴㄴ 가장 높은 품질 유지 단 메모리 사용량 많음
//Low Quality : 가장 높은 압축률을 적용하며 품질 낮아도 메모리 샤용랑이 적음
//Normal Quality : 품질과 압축률의 균형을 맞춘
//Hight Quality : 압축률이 낮고 품질이 가장 좋은 메모리 사용량은 늘어도 높은 품질을 유지해야 하는 겨웅에는 적합합니다.