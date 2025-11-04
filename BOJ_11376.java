import java.io.IOException;
import java.util.Arrays;

public class BOJ_11376{
	
	static int worker[][], work[], visit[], n, m, turn = 1, ans;
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		m = nex();
		
		worker = new int[n][];
		work = new int[m+1];
		visit = new int[n];
		
		Arrays.fill(work, -1);
		
		for(int i = 0; i < n; i++) {
			worker[i] = new int[nex()];
			for(int j = 0; j < worker[i].length; j++)
				worker[i][j] = nex();
		}
		
		for(int i = 0; i < n; i++) {
			if(match(i)) ans++;
			turn++;
			if(match(i)) ans++;
			turn++;
		}
		
		System.out.print(ans);
	}
	
	static boolean match(int cur) {
		if(visit[cur]==turn) return false;
		
		visit[cur] = turn;
		
		for(int i = 0; i < worker[cur].length; i++) {
			if(work[worker[cur][i]]==-1||match(work[worker[cur][i]])) {
				work[worker[cur][i]] = cur;
				return true;
			}
		}
		
		return false;
	}
	
	static int nex() throws IOException{
		int n, c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
