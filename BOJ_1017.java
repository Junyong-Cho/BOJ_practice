import java.io.IOException;
import java.util.Arrays;

public class BOJ_1017{
	
	static StringBuilder ans = new StringBuilder();
	static int n, a[], b[], ac, bc, visit[], match[], turn;
	static boolean era[] = new boolean[2000];
	
	static {
		era[0] = era[1] = true;
		for(int i = 2; i < 46; i++)
			if(!era[i])
				for(int j = i*i; j < 2000; j += i)
					era[j] = true;
	}
	
	static public void main(String catchsunpie[]) throws IOException{
		
		n = nex();
		a = new int[n>>1];
		b = new int[n>>1];
		match = new int[n>>1];
		visit = new int[n>>1];
		
		a[0] = nex();
		ac = 1;
		
		for(int i = 1; i < n; i++) {
			int t = nex();
			if((t&1)==(a[0]&1)) {
				if(ac==n>>1) {
					System.out.print(-1);
					return;
				}
				a[ac++] = t;
			}
			else {
				if(bc==n>>1) {
					System.out.println(-1);
					return;
				}
				b[bc++] = t;
			}
		}
		
		n >>= 1;
		Arrays.sort(b);
		
		L:
		for(int cur = 0; cur < n; cur++) {
			if(!era[a[0]+b[cur]]) {
				Arrays.fill(match, -1);
				Arrays.fill(visit,-1);
				match[cur] = 0;
				for(turn = 1; turn < n; turn++)
					if(!match(turn)) continue L;
				ans.append(b[cur]).append(" ");
			}
		}
		
		System.out.println(ans.length()==0?-1:ans);
	}
	
	static boolean match(int cur) {
		if(visit[cur]==turn) return false;
		visit[cur] = turn;
		for(int i = 0; i < n; i++) {
			if(!era[a[cur]+b[i]]) {
				if(match[i]==0) continue;
				if(match[i]==-1||match(match[i])) {
					match[i] = cur;
					return true;
				}
			}
		}
		
		return false;
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