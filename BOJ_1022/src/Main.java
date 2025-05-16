import java.util.Arrays;
import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;

public class Main {
	
	static int r1,c1,r2,c2, grid[][], n = 10002, count = n*n, max;
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	static int dir[][] = {{0,1},{1,0},{0,-1},{-1,0}};
	static String format;
	
	static public void main(String catchsunpie[]) throws IOException{
		grid = new int[n+2][n+2];
		Arrays.fill(grid[0] = grid[n+1], -1);
		
		for(int i = 1; i <= n; i++)
			grid[i][0] = grid[i][n+1] = -1;
		
		int r, c = r = 1;
		int d = 0;
		
		while(count>1) {
			grid[r][c] = count--;
			int nr, nc;
			while(grid[nr = r+dir[d][0]][nc = c+dir[d][1]]!=0)
				d = (d+1)%4;
			r = nr;
			c = nc;
		}
		
		grid[r][c] = 1;
		
		r1 = nex()+r;
		c1 = nex()+c;
		r2 = nex()+r;
		c2 = nex()+c;
		
		max = max(grid[r1][c1],max(grid[r1][c2],max(grid[r2][c1],grid[r2][c2])));
		
		max = Integer.toString(max).length();
		
		format = "%"+max+"d ";
		
		for(int i = r1; i <= r2; i++) {
			for(int j = c1; j <= c2; j++)
				bw.write(String.format(format, grid[i][j]));
			bw.write("\n");
		}
		
		bw.flush();
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
	
	static int nex() throws IOException{
		int n,c;
		boolean pos = true;
		while((n = System.in.read())<=' ');
		if(n=='-') {
			pos = false;
			n = System.in.read();
		}
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return pos?n:~n+1;
	}
}
