using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertex
{
    public Vector2 VertexPos;//Vertex의 위치
    public Vertex PreVertexAddr;//나를 가리키는 이전 Vertex의 주소 값

    public Vertex(Vector2 pos)
    {
        VertexPos = pos;
        PreVertexAddr = null;
    }

}
