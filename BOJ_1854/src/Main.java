import java.io.IOException;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;
import java.util.Arrays;
import java.util.PriorityQueue;

public class Main {
	
	static int n,m,k,nodes[][], ans[][], count = 0;
	static final int INF = 1000001;
	static PriorityQueue<int[]> pq = new PriorityQueue<>((i,j)->{
		return i[1]-j[1];
	});
	static BufferedWriter bw = new BufferedWriter(new OutputStreamWriter(System.out));
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		m = nex();
		k = nex();
		
		nodes = new int[n+1][n+1];
		ans = new int[n+1][2];
		
		for(int i = 1; i <= n; i++) {
			Arrays.fill(nodes[i], INF);
			ans[i][1] = -1;
		}
		
		ans[1][0] = 1;
		if(k==1) ans[1][1] = 0;
		
		while(m-->0)
			nodes[nex()][nex()] = nex();
		
		
		for(int i = 1; i <= n; i++)
			if(nodes[1][i]!=INF)
				pq.add(new int[] {i,nodes[1][i]});
		
		while(!pq.isEmpty()) {
			int t[] = pq.remove();
			if(ans[t[0]][0]>=k) continue;
			if(++ans[t[0]][0]==k) {
				ans[t[0]][1] = t[1];
				if(++count==n) break;
			}
			for(int i = 1; i <= n; i++) {
				if(nodes[t[0]][i]==INF) continue;
				pq.add(new int[] {i,t[1]+nodes[t[0]][i]});
			}
		}
		
		for(int i = 1; i <= n; i++)
			bw.write((ans[i][1]>=INF?-1:ans[i][1])+"\n");
		
		bw.flush();
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
