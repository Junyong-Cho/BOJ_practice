import java.io.IOException;
import java.util.Arrays;

public class BOJ_2568{
	
	static int n, line[][], lis;
	static Node bound[];
	static boolean canLink[];
	static StringBuilder ans = new StringBuilder();
	
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
		line = new int[n][2];
		
		for(int i = 0; i < n; i++) {
			line[i][0] = nex();
			line[i][1] = nex();
		}
		
		Arrays.sort(line,(i,j)->{
			return i[0]-j[0];
		});
		
		bound = new Node[n+1];
		
		bound[1] = new Node(0,null);
		lis = 1;
		
		for(int i = 1; i < n; i++) {
			int t = line[i][1];
			if(line[bound[lis].index][1]<t) {
				bound[++lis] = new Node(i,bound[lis-1]);
				continue;
			}
			if(t<line[bound[1].index][1]) {
				bound[1] = new Node(i,null);
			}
			int low = 1, high = lis;
			while(true) {
				int mid = (high+low)>>1;
				if(line[bound[mid].index][1]<t) {
					if(t<line[bound[mid+1].index][1]) {
						bound[mid+1] = new Node(i,bound[mid]);
						break;
					}
					low = mid;
				}
				else if(t<line[bound[mid].index][1]) {
					if(line[bound[mid-1].index][1]<t) {
						bound[mid] = new Node(i,bound[mid-1]);
						break;
					}
					high = mid;
				}
				else break;
			}
		}
		
		ans.append(n-lis).append("\n");
		
		canLink = new boolean[n];
		
		Node t = bound[lis];
		
		while(t!=null) {
			canLink[t.index] = true;
			t = t.next;
		}
		
		for(int i = 0; i < n; i++)
			if(!canLink[i])
				ans.append(line[i][0]).append("\n");
		
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

