import java.util.Arrays;
import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;

public class Main{
	
	static int r1,r2,c1,c2, grid[][];
	static boolean tonado[][];
	static int dir[][] = {{0,-1},{-1,0},{0,1},{1,0}};
	static String format;
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	
	static public void main(String catchsunpie[]) throws IOException{
		r1 = nex();
		c1 = nex();
		r2 = nex();
		c2 = nex();
		
		grid = new int[r2-r1+1][c2-c1+1];
		
		tonado = new boolean[10003][10003];
		
		Arrays.fill(tonado[0] = tonado[10002], true);
		for(int i = 1; i <= 10001; i++)
			tonado[i][0] = tonado[i][10002] = true;
		
		int count = 10001*10001;
		
		int r, c = r = 10001;
		int d = 0;
		
		while(true) {
			tonado[r][c] = true;
			
			if(inbounds(r,c))
				grid[r-r1][c-c1] = count;
			
			count--;
			
			if(count==0) break;
			
			int nr,nc;
			
			while(tonado[nr = r+dir[d][0]][nc = c+dir[d][1]])
				d = (d+1)%4;
			
			r = nr;
			c = nc;
		}
		
		int max = max(grid[0][0],max(grid[0][c2-c1],max(grid[r2-r1][0],grid[r2-r1][c2-c1])));
		
		max = len(max);
		
		format = "%"+max+"d ";
		
		for(int i = 0; i < grid.length; i++) {
			for(int j = 0; j < grid[i].length; j++)
				bw.write(String.format(format, grid[i][j]));
			bw.write("\n");
		}
		
		bw.flush();
	}
	
	static boolean inbounds(int r, int c) {
		return r1<=r&&r<=r2&&c1<=c&&c<=c2;
	}
	
	static int len(int i) {
		if(i==0) return 1;
		int len = 0;
		while(i>0) {
			i /= 10;
			len++;
		}
		return len;
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
		return (pos?n:~n+1)+5001;
	}
}