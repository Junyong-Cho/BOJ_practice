import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class BOJ_1701{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static int n, p[], ans;
	static char c[];
	
	static public void main(String catchsunpie[]) throws IOException{
		c = br.readLine().toCharArray();
		n = c.length;
		p = new int[n];

		for(int i = 0; i < n-ans; i++) {
			for(int j = 1, k = 0; j < n-i; j++) {
				p[j] = 0;
				while(k>0&&c[i+j]!=c[i+k])
					k = p[k-1];
				if(c[i+j]==c[i+k])
					ans = max(ans,p[j] = ++k);
			}
		}
		
		System.out.print(ans);
	}
	
	static int max(int i, int j) {
		return i>j?i:j;
	}
}