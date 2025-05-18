import java.io.IOException;
import java.util.Arrays;
import java.util.PriorityQueue;

public class Main {
	
	static PriorityQueue<int[]> pq = new PriorityQueue<>((i,j)->{
		return i[1]-j[1];
	});
	static StringBuilder sb = new StringBuilder();
	static int n, m, nodes[][], src, dist, vc;
	static final int INF = 100000001;
	static boolean visit[];
	static Node no[];
	
	static class Node{
		int index;
		Node next;
		Node(int i, Node n){
			index = i;
			next = n;
		}
	}
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		m = nex();
		
		nodes = new int[n+1][n+1];
		no = new Node[n+1];
		visit = new boolean[n+1];
		vc = 0;
		
		for(int i = 1; i <= n; i++) {
			Arrays.fill(nodes[i], INF);
			nodes[i][i] = 0;
		}
		
		while(m-->0) {
			int a = nex();
			int b = nex();
			nodes[a][b] = min(nodes[a][b],nex());
		}
		
		src = nex();
		dist = nex();
		no[src] = new Node(src, null);
		
		for(int i = 1; i < src; i++)
			if(nodes[src][i]!=INF) {
				pq.add(new int[] {i,nodes[src][i]});
				no[i] = new Node(i,no[src]);
			}
		for(int i = src+1; i <= n; i++)
			if(nodes[src][i]!=INF) {
				pq.add(new int[] {i,nodes[src][i]});
				no[i] = new Node(i,no[src]);
			}
		
		while(!pq.isEmpty()) {
			int t[] = pq.remove();
			if(visit[t[0]]) continue;
			visit[t[0]] = true;
			if(t[1]==dist||++vc==n) break;
			for(int i = 1; i <=n; i++) {
				if(nodes[src][t[0]]+nodes[t[0]][i]<nodes[src][i]) {
					nodes[src][i] = nodes[src][t[0]]+nodes[t[0]][i];
					no[i] = new Node(i,no[t[0]]);
				}
			}
		}
		
		sb.append(nodes[src][dist]).append("\n");
		
		route(no[dist], 1);
		
		System.out.println(sb);
	}
	
	static void route(Node n, int count) {
		if(n.next==null) {
			sb.append(count).append("\n").append(n.index).append(" ");
			return;
		}
		else
			route(n.next,count+1);
		sb.append(n.index).append(" ");
	}
	
	static int min(int i, int j) {
		return i<j?i:j;
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
