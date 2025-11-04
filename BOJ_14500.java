import java.io.IOException;

public class BOJ_14500 {
	
	static int n, m, grid[][], ans;
	static int tet[][] = new int[4][2];
	static boolean visit[][];
	
	static public void main(String catchsunpie[])	 throws IOException{
		n = nex();
		m = nex();
		
		grid = new int[n+2][m+2];
		visit = new boolean[n+1][m+1];
		
		for(int i = 1; i <= n; i++)
			for(int j = 1; j <= m; j++)
				grid[i][j] = nex();
		
		for(int i = 1; i <= n; i++)
			for(int j = 1; j <= m; j++) {
				visit[i][j] = true;
				tet[0][0] = i;
				tet[0][1] = j;
				tetromino(i,j,1,grid[i][j]);
			}
		
		System.out.println(ans);
	}
	
	static int dir[][] = {{1,0},{0,1},{-1,0},{0,-1}};
	
	static void tetromino(int i, int j, int len, int sum) {
		if(len==3) {
			for(int t = 0; t < 3; t++)
				for(int d[] : dir) {
					int r = tet[t][0]+d[0];
					int c = tet[t][1]+d[1];
					if(grid[r][c]==0||visit[r][c]) continue;
					ans = max(ans,sum+grid[r][c]);
				}
			
			return;
		}
		
		for(int d[] : dir) {
			int r = i+d[0];
			int c = j+d[1];
			if(grid[r][c]==0||visit[r][c]) continue;
			visit[r][c] = true;
			tet[len][0] = r;
			tet[len][1] = c;
			tetromino(r,c,len+1,sum+grid[r][c]);
			visit[r][c] = false;
		}
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
	
	static int nex() throws IOException{
		int n,c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}

