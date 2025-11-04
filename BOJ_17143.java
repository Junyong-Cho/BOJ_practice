import java.io.IOException;
import java.util.Queue;
import java.util.LinkedList;

public class BOJ_17143{
	
	static class Shark{
		int row, col, spd, dir, siz;
		
		Shark(int ro, int co, int s, int d, int z){
			row = ro;
			col = co;
			spd = s;
			dir = d-1;
			siz = z;
			
			if(dir<2) {
				spd = spd%((r-1)<<1);
			}
			else {
				spd = spd%((c-1)<<1);
			}
		}
	}
	
	static int dir[][] = {{-1,0},{1,0},{0,1},{0,-1}};
	static int r,c,m,ans;
	static Shark sha[][];
	static Queue<int[]> q = new LinkedList<>();
	static Queue<Shark> shark = new LinkedList<>();
	
	static public void main(String catchsunpie[]) throws IOException{
		r = nex();
		c = nex();
		m = nex();
		
		sha = new Shark[r+1][c+1];
		
		while(m-->0) {
			int r = nex();
			int c = nex();
			q.add(new int[] {r,c});
			sha[r][c] = new Shark(r,c,nex(),nex(),nex());
		}
		
		for(int i = 1; i <= c; i++) {
			for(int j = 1; j <= r; j++) {
				if(sha[j][i]!=null) {
					ans += sha[j][i].siz;
					sha[j][i] = null;
					break;
				}
			}
			move();
		}
		
		System.out.println(ans);
	}
	
	static void move() {
		
		while(!q.isEmpty()) {
			int t[] = q.remove();
			if(sha[t[0]][t[1]]==null) continue;
			Shark sh = sha[t[0]][t[1]];
			sha[t[0]][t[1]] = null;
			
			t[0] += dir[sh.dir][0]*sh.spd;
			t[1] += dir[sh.dir][1]*sh.spd;
			
			if(t[0]<1) {
				t[0] = 2-t[0];
				if(t[0]<=r)
					sh.dir++;
				else
					t[0] = (r<<1)-t[0];
			}
			else if(r<t[0]) {
				t[0] = (r<<1)-t[0];
				if(0<t[0])	
					sh.dir--;
				else
					t[0] = 2-t[0];
			}
			else if(t[1]<1) {
				t[1] = 2-t[1];
				if(t[1]<=c)
					sh.dir--;
				else
					t[1] = (c<<1)-t[1];
			}
			else if(c<t[1]) {
				t[1] = (c<<1)-t[1];
				if(0<t[1])
					sh.dir++;
				else
					t[1] = 2-t[1];
			}
			
			sh.row = t[0];
			sh.col = t[1];
			shark.add(sh);
		}
		
		while(!shark.isEmpty()) {
			Shark sh = shark.remove();
			if(sha[sh.row][sh.col]==null) {
				sha[sh.row][sh.col] = sh;
				q.add(new int[]{sh.row,sh.col});
			}
			else {
				if(sha[sh.row][sh.col].siz<sh.siz)
					sha[sh.row][sh.col] = sh;
			}
		}
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
