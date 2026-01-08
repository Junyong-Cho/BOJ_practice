import java.io.IOException;
import java.util.Arrays;

public class BOJ_1266{
	
	static class Node{
		Node next;
		int index, count;
		Node(int i){
			index = i;
			count = 1;
		}
		Node(int i, Node n){
			index = i;
			count = n.count+1;
			next = n;
		}
	}
	static Node d[];
	static int n, party[][], sum;
	static StringBuilder ans = new StringBuilder();
	
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		party = new int[n][2];
		
		for(int i = 0; i < n; i++) {
			sum += party[i][0] = nex();
			party[i][1] = i+1;
		}
		
		d = new Node[sum+1];
		
		Arrays.sort(party,(i,j)->{
			return j[0]-i[0];
		});
		
		for(int i = 0; i < n; i++) {
			for(int j = min(sum,(sum>>1)+party[i][0]); j > party[i][0]; j--) {
				if(d[j-party[i][0]]==null||d[j]!=null)
					continue;
				d[j] = new Node(i,d[j-party[i][0]]);
			}
			
			d[party[i][0]] = new Node(i);
		}
		
		while(d[sum]==null) {
			sum--;
		}
		
		ans.append(d[sum].count).append("\n");
		Node t = d[sum];
		
		while(t!=null) {
			ans.append(party[t.index][1]).append(" ");
			t = t.next;
		}
		
		System.out.print(ans);
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
