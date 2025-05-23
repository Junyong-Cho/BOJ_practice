import java.io.IOException;
import java.util.Arrays;
import java.util.Queue;
import java.util.LinkedList;

public class Main {
	
	static int board[][][], ans = 300;
	static int stars[][] = new int[5][2], size;
	static int order[] = new int[5];
	static int shape[][] = new int[5][2];
	static boolean visit[][] = new boolean[7][7];
	static boolean v[] = new boolean[5];

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
		Arrays.fill(visit[0] = visit[6], true);
		
		for(int i = 1; i < 6; i++)
			visit[i][0] = visit[i][6] = true;
		
		for(int i = 1; i < size; i++)
			board[i][0] = board[i][6] = board[0][0];
		
		for(int i = 0; i < size; i++)
			for(int j = 1; j < 6; j++) {
				Arrays.fill(board[i][j], 25);
				board[i][j][0] = board[i][j][6] = -1;
			}
		for(int i = 0; i < size; i++)
			bfs(i,stars[i][0],stars[i][1]);
		
		for(int i = 1; i < 6; i++)
			for(int j = 1; j < 6; j++) {
				visit[i][j] = true;
				shape[0][0] = i;
				shape[0][1] = j;
				tracking(i,j,1);
			}
		
		System.out.println(ans);
	}
	
	static void tracking(int r, int c, int len) {
		if(len==size-1) {
			
			for(int i = 0; i < size-1; i++) {
				for(int d[] : dir) {
					if(visit[shape[i][0]+d[0]][shape[i][1]+d[1]]) continue;
					shape[size-1][0] = shape[i][0]+d[0];
					shape[size-1][1] = shape[i][1]+d[1];
					calc(0);
				}
			}
			
			return;
		}
		
		for(int d[] : dir) {
			int nr = r+d[0];
			int nc = c+d[1];
			if(visit[nr][nc]) continue;
			visit[nr][nc] = true;
			shape[len][0] = nr;
			shape[len][1] = nc;
			tracking(nr,nc,len+1);
			visit[nr][nc] = false;
		}
	}
	
	static void calc(int odr) {
		if(odr==size) {
			int sum = 0;
			for(int i = 0; i < size; i++)
				sum += board[order[i]][shape[i][0]][shape[i][1]];
			ans = min(ans,sum);
			return;
		}
		for(int i = 0; i < size; i++) {
			if(v[i]) continue;
			v[i] = true;
			order[odr] = i;
			calc(odr+1);
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
