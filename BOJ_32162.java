import java.io.IOException;
import java.util.PriorityQueue;

public class BOJ_32162{
	
	static int a[] = new int[100001], t;
	static StringBuffer ans = new StringBuffer();
	static PriorityQueue<Integer> pq = new PriorityQueue<>();
	static boolean hash[] = new boolean[167219];
	
	static public void main(String catchsunpie[]) throws IOException{
		
		a[1] = 1;
		pq.add(15);
		pq.add(27);
		pq.add(125);
		
		for(int i = 2, cur = 2; i < 100001; cur++) {
			while(i<100001&&pq.peek()<cur) {
				t = pq.remove();
				if(hash[t]) continue;
				a[i++] = t;
				hash[t] = true;
				pq.add(t*15);
				pq.add(t*27);
				pq.add(t*125);
			}
			if(i<100001&&cur%3!=0&&cur%5!=0) {
				a[i++] = cur;
				hash[cur] = true;
				pq.add(cur*15);
				pq.add(cur*27);
				pq.add(cur*125);
			}
		}
		
		t = nex();
		while(t-->0)
			ans.append(a[nex()]).append("\n");
		System.out.print(ans);
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
