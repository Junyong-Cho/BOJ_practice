import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.Arrays;

public class BOJ_26638{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static char[] pre = new char[200100], cur;
	static int n, size;
	static long ans;
	
	static public void main(String catchsunpie[]) throws IOException{
		n = Integer.parseInt(br.readLine())-1;
		cur = br.readLine().toCharArray();
		
		size = cur.length;
		
		Arrays.fill(pre, '0');
		System.arraycopy(cur, 0, pre, 0, size);
		
		L:
		while(n-->0) {
			cur = br.readLine().toCharArray();
			if(cur.length>size) {
				System.arraycopy(cur, 0, pre, 0, cur.length);
				size = cur.length;
			}
			else {
				ans += size-cur.length;
				for(int i = 0; i < cur.length; i++) {
					if(cur[i]<pre[i]) {
						System.arraycopy(cur,i,pre,i,cur.length-i);
						Arrays.fill(pre, cur.length, size, '0');
						size++;
						ans++;
						continue L;
					}
					else if(cur[i]>pre[i]) {
						System.arraycopy(cur,i,pre,i,cur.length-i);
						Arrays.fill(pre, cur.length, size, '0');
						continue L;
					}
				}
				for(int i = size-1; i >= cur.length; i--) {
					if(pre[i]!='9') {
						pre[i] = (char)(pre[i]+1);
						continue L;
					}
					pre[i] = '0';
				}
				size++;
				ans++;
			}
		}
		
		System.out.println(ans);
	}
}
