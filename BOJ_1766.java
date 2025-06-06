import java.io.IOException;
import java.util.PriorityQueue;

public class BOJ_1766 {
	
	static StringBuilder ans = new StringBuilder();
	static int n, m;
	static boolean solved[];
	static Node node[];
	
	static class Node{
		int index;
		Node next, pre;
		PriorityQueue<Node> pq = new PriorityQueue<>((i,j)->{
			return i.index-j.index;
		});
		
		Node(int i, Node p){
			index = i;
			pre = p;
		}
	}
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		m = nex();
		
		node = new Node[n+1];
		solved = new boolean[n+1];
		
		node[0] = new Node(-1,null);
		for(int i = 1; i < n; i++) {
			node[i] = new Node(i,node[i-1]);
			node[i-1].next = node[i];
		}
		node[n] = new Node(n,node[n-1]);
		node[n-1].next = node[n];
		
		while(m-->0) {
			int a = nex();
			node[nex()].pq.add(node[a]);
		}
		
		L:
		while(true) {
			for(Node t = node[0].next; t!=null; t = t.next) {
				while(!t.pq.isEmpty()) {
					if(solved[t.pq.peek().index])
						t.pq.remove();
					else break;
				}
				if(t.pq.isEmpty()) {
					solved[t.index] = true;
					ans.append(t.index).append(" ");
					t.pre.next = t.next;
					if(t.next!=null)
						t.next.pre = t.pre;
					continue L;
				}
			}
			break;
		}
		
		System.out.println(ans);
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
