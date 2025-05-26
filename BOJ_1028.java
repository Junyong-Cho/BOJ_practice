import java.io.IOException;

public class BOJ_1028 {
	
	static int r,c,grid[][],ans;
	static int dir[][] = {{1,1},{-1,1},{-1,-1}};
	static boolean visit[][];
	
	static public void main(String args[]) throws IOException{
		r = nex();
		c = nex();
		grid = new int[r+2][c+2];
		visit = new boolean[r+1][c+1];
		
		for(int i = 1; i <= r; i++) {
			while((grid[i][1] = System.in.read())<=' ');
			ans = grid[i][1] &= 1;
			for(int j = 2; j <= c; j++)
				ans = grid[i][j] = System.in.read()&1;
		}
		
		for(int i = 1; i <= r-(ans<<1); i++)
			for(int j = ans+1; j <= c-ans; j++)
				if(grid[i][j]==1&&!visit[i][j])
					oper(i,j);
		
		System.out.println(ans);
	}
	
	static void oper(int r, int c) {
		int len = 0;
		
		while(grid[r][c]==1) {
			visit[r][c] = true;
			r++;
			c--;
			len++;
		}
		
		r--;
		c++;
		
		while(len>ans) {
			if(diamond(r,c,len)) {
				ans = len;
				break;
			}
			len--;
			r--;
			c++;
		}
	}
	
	static boolean diamond(int r, int c, int len) {
		for(int d[] : dir) {
			for(int i = 1; i < len; i++) {
				r += d[0];
				c += d[1];
				if(grid[r][c]==0) return false;
			}
		}
		
		return true;
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
