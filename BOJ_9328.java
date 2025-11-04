import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.StringTokenizer;
import java.util.Queue;
import java.util.LinkedList;

public class BOJ_9328 {
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static StringBuilder sb = new StringBuilder();
	static StringTokenizer st;
	static Queue<int[]> q = new LinkedList<>();
	static Queue<int[]> keep;
	static int t, h, w, ans;
	static boolean key[];
	static char board[][];
	static final int DIR[][] = {{1,0},{0,1},{-1,0},{0,-1}};
	
	public static void main(String catchsunpie[]) throws IOException{
		t = Integer.parseInt(br.readLine());
		
		while(t-->0) {
			st = new StringTokenizer(br.readLine());
			h = Integer.parseInt(st.nextToken());
			w = Integer.parseInt(st.nextToken());
			board = new char[h+2][];
			board[0] = board[h+1] = new char[w+2];
			key = new boolean[26];
			keep = new LinkedList<>();
			ans = 0;
			for(int i = 0; i <= w; i++)
				board[0][i] = '*';
			for(int i = 1; i <= h; i++)
				board[i] = ("*"+br.readLine()+"*").toCharArray();
			
			char c[] = br.readLine().toCharArray();
			
			if(c[0]!='0')
				for(int i = 0; i < c.length; i++)
					key[c[i]-'a'] = true;
			
			for(int i = 1; i <= w; i++) {
				if(board[1][i]!='*')
					bfs(1,i);
				if(board[h][i]!='*')
					bfs(h,i);
			}
			
			for(int i = 1; i <= h; i++) {
				if(board[i][1]!='*')
					bfs(i,1);
				if(board[i][w]!='*')
					bfs(i,w);
			}
			
			sb.append(ans).append("\n");
		}
		
		System.out.println(sb);
	}
	
	static void bfs(int r, int c) {
		if(board[r][c]>='a')
			key[board[r][c]-'a'] = true;
		else if(board[r][c]>='A') {
			if(!key[board[r][c]-'A']) {
				keep.add(new int[] {r,c});
				return;
			}
		}
		else if(board[r][c]=='$')
			ans++;
		
		board[r][c] = '*';
		
		q.add(new int[] {r,c});
		boolean findKey = true;
		
		while(findKey) {
			findKey = false;
			while(!q.isEmpty()) {
				int t[] = q.remove();
				if(board[t[0]][t[1]]!='*') {
					if(!key[board[t[0]][t[1]]-'A']) {
						keep.add(t);
						continue;
					}
					board[t[0]][t[1]] = '*';
				}
				
				for(int d[] : DIR) {
					r = d[0]+t[0];
					c = d[1]+t[1];
					
					if(board[r][c]=='*') continue;
					if(board[r][c]>='a') {
						key[board[r][c]-'a'] = true;
						findKey = true;
					}
					else if(board[r][c]>='A') {
						if(!key[board[r][c]-'A']) {
							keep.add(new int[] {r,c});
							continue;
						}
					}
					else if(board[r][c]=='$')
						ans++;
					board[r][c] = '*';
					
					q.add(new int[] {r,c});
				}
			}
			if(findKey) 
				while(!keep.isEmpty())
					q.add(keep.remove());
		}
	}
}

