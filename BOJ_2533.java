import java.io.IOException;
import java.util.Queue;
import java.util.LinkedList;

public class BOJ_2533{
	
	static class Node{
		boolean visit, early;
		Queue<Node> friends = new LinkedList<>();
		
		void add(Node n) {
			friends.add(n);
			n.friends.add(this);
		}
	}
	
	static int n, m, ans;
	static Node sns[];
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		m = n-1;
		sns = new Node[n+1];
		
		for(int i = 1; i <= n; i++)
			sns[i] = new Node();
		
		while(m-->0)
			sns[nex()].add(sns[nex()]);
		
		for(int i = 1; i <= n; i++)
			dfs(sns[i]);
		
		System.out.println(ans);
	}
	
	static boolean dfs(Node n) {
		n.visit = true;
		
		boolean check = true;
		
		while(!n.friends.isEmpty()) {
			Node t = n.friends.remove();
			if(t.visit) continue;
			check = check&&dfs(t);
		}
		
		if(!check) {
			ans++;
			n.early = true;
		}
		return n.early;
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