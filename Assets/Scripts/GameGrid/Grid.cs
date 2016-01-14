using UnityEngine;
using System.Collections;

namespace GameGrid
{
	public class Grid
	{
		public const int GRID_CELL_SIZE = 1;
		private const int GRID_SIZE_X = 10;
		private const int GRID_SIZE_Y = 10;
		private Cell[,] m_Cells;

		public int SizeX {get; private set;}
		public int SizeY {get; private set;}

		public Grid()
		{

		}

		/// <summary>
		/// Init this instance.
		/// </summary>
		private void Init()
		{
			m_Cells = new Cell[GRID_SIZE_X, GRID_SIZE_Y];
			SizeX = GRID_SIZE_X;
			SizeY = GRID_SIZE_Y;
			for (int x = 0; x < GRID_SIZE_X; x++) 
			{
				for (int y = 0; y < GRID_SIZE_Y; y++) 
				{
					Cell cell = new Cell(x, y);
					cell.State = CellState.Free;
					m_Cells[x, y] = cell;
				}
			}
			CreatePlane(GRID_SIZE_X, GRID_SIZE_Y);
		}

		/// <summary>
		/// Load the grid from file
		/// </summary>
		public void Load(string fileName)
		{
			//TODO Add loading code here, then init with loaded data
			Init();
		}

		public Cell GetCell(int x, int y)
		{
			if (m_Cells.GetLength(0) > x && m_Cells.GetLength(1) > y)
			{
				return m_Cells[x, y];
			}
			return null;
		}

		private void CreatePlane(int sizeX, int sizeY)
		{
			Mesh mesh = CreateMesh(sizeX, sizeY);
			GameObject go = new GameObject("GridPlane");
			MeshFilter meshFilter = go.AddComponent<MeshFilter>();
			meshFilter.sharedMesh = mesh;
				go.AddComponent<MeshRenderer>();
		}

		private Mesh CreateMesh(float fWidht, float fHeight)
		{
			Mesh pMesh = new Mesh();
			
			Vector3[] verticies = new Vector3[4];
			Vector2[] uv 		= new Vector2[4];
			int[] 	  triangles = new int[6];

			// 1----3
			// |    |
			// |    |
			// 0----2
			verticies[0] = new Vector3(0.0f, 0.0f, 0.0f);
			verticies[1] = new Vector3(0.0f, 0.0f, fHeight);
			verticies[2] = new Vector3(fWidht, 0.0f, 0.0f);
			verticies[3] = new Vector3(fWidht, 0.0f, fHeight);
			
			uv[0] = new Vector2(0.0f, 1.0f);
			uv[1] = new Vector2(1.0f, 1.0f);
			uv[2] = new Vector2(0.0f, 0.0f);
			uv[3] = new Vector2(1.0f, 0.0f);
			
			triangles[0] = 0;
			triangles[1] = 1;
			triangles[2] = 2;
			
			triangles[3] = 2;
			triangles[4] = 1;
			triangles[5] = 3;
			
			pMesh.vertices  = verticies;
			pMesh.uv 		= uv;
			pMesh.triangles = triangles;
			
			return pMesh;
		}

	}
}