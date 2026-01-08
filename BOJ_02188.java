import java.io.IOException;
import java.util.Arrays;

public class BOJ_02188{
	
	static int n, m, ans, cow[][], room[], visit[], turn;
	
	static public void main(String catchsunpie[]) throws IOException{
		
		n = nex();
		m = nex();
		
		cow = new int[n][];
		room = new int[m+1];
		visit = new int[n];
		
		for(int i = 0; i < n; i++) {
			cow[i] = new int[nex()];
			for(int j = 0; j < cow[i].length; j++)
				cow[i][j] = nex();
		}
		
		Arrays.fill(room, -1);
		Arrays.fill(visit,-1);
		
		for(turn = 0; turn < n; turn++)
			if(match(turn)) ans++;
		
		System.out.print(ans);
	}
	
	static boolean match(int cur) {
		if(visit[cur]==turn) return false;
		visit[cur] = turn;
		
		for(int i = 0; i < cow[cur].length; i++) {
			if(room[cow[cur][i]]==-1||match(room[cow[cur][i]])) {
				room[cow[cur][i]] = cur;
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
