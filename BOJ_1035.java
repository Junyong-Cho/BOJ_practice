import java.io.IOException;
import java.util.Arrays;
import java.util.Queue;
import java.util.LinkedList;

public class BOJ_1035 {
	
	static int board[][][], ans = 300;
	static int stars[][] = new int[5][2], size;
	static boolean visit[][] = new boolean[7][7];
	static int order[], link[][];
	static boolean v[];

	static public void main(String catchsunpie[]) throws IOException{
		
		for(int i = 1; i < 6; i++) {
			int c;
			while((c=System.in.read())<=' ');
			if(c=='*') {
				stars[size][0] = i;
				stars[size++][1] = 1;
			}
			for(int j = 2; j < 6; j++) {
				if((c = System.in.read())=='*') {
					stars[size][0] = i;
					stars[size++][1] = j;
				}
			}
		}
		
		if(size==1) {
			System.out.println(0);
			return;
		}
		
		board = new int[size][7][7];
		
		Arrays.fill(board[0][0] = board[0][6], -1);
		
		for(int i = 1; i < size; i++)
			board[i][0] = board[i][6] = board[0][0];
		
		for(int i = 0; i < size; i++)
			for(int j = 1; j < 6; j++) {
				Arrays.fill(board[i][j], 25);
				board[i][j][0] = board[i][j][6] = -1;
			}
		for(int i = 0; i < size; i++)
			bfs(i,stars[i][0],stars[i][1]);
		
		Arrays.fill(visit[0] = visit[6], true);
		for(int i = 1; i < 6; i++)
			visit[i][0] = visit[i][6] = true;
		
		link = new int[size][2];
		order = new int[size];
		v = new boolean[size];
		
		if(size==5) 
			for(int i = 2; i < 5; i++)
				for(int j = 2; j < 5; j++) {
					link[0][0] = i;
					link[0][1] = j;
					cross(i,j);
				}
		
		for(int i = 1; i < 6; i++)
			for(int j = 1; j < 6; j++) {
				visit[i][j] = true;
				link[0][0] = i;
				link[0][1] = j;
				linking(i,j,1);
			}
		
		System.out.println(ans);
	}
	
	static void cross(int r, int c) {
		for(int i = 0; i < 4; i++) {
			link[i+1][0] = r+dir[i][0];
			link[i+1][1] = c+dir[i][1];
		}
		calc(0);
	}
	
	static void linking(int r, int c, int len) {
		if(len==size-1) {
			for(int i = 0; i < len; i++)
				for(int d[]: dir) {
					int nr = link[i][0]+d[0];
					int nc = link[i][1]+d[1];
					if(visit[nr][nc]) continue;
					link[len][0] = nr;
					link[len][1] = nc;
					calc(0);
				}
			return;
		}
		
		for(int d[] : dir) {
			int nr = r+d[0];
			int nc = c+d[1];
			if(visit[nr][nc]) continue;
			visit[nr][nc] = true;
			link[len][0] = nr;
			link[len][1] = nc;
			linking(nr,nc,len+1);
			visit[nr][nc] = false;
		}
	}
	
	static void calc(int or) {
		if(or==size) {
			int sum = 0;
			for(int i = 0; i < size; i++)
				sum += board[order[i]][link[i][0]][link[i][1]];
			
			ans = min(ans,sum);
			return;
		}
		
		for(int i = 0; i < size; i++) {
			if(v[i]) continue;
			v[i] = true;
			order[or] = i;
			calc(or+1);
			v[i] = false;
		}
	}
	
	static int dir[][] = {{-1,0},{0,-1},{1,0},{0,1}};
	static Queue<int[]> q = new LinkedList<>();
	
	static void bfs(int index, int r, int c) {
		int bd[][] = board[index];
		bd[r][c] = 0;
		
		q.add(new int[] {r,c,0});
		
		while(!q.isEmpty()) {
			int t[] = q.remove();
			int dist = t[2]+1;
			for(int d[] : dir) {
				int nr = t[0] + d[0];
				int nc = t[1] + d[1];
				if(bd[nr][nc]==-1||bd[nr][nc]<=dist) continue;
				bd[nr][nc] = dist;
				q.add(new int[] {nr,nc,dist});
			}
		}
	}
	
	static int min(int i, int j) {
		return i<j?i:j;
	}

}

