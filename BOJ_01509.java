import java.io.IOException;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class BOJ_01509{
	
	static BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
	static char c[];
	static int n, d[][], dp[];
	
	static public void main(String catchsunpie[]) throws IOException{
		c = br.readLine().toCharArray();
		
		n = c.length;
		d = new int[n][n];
		dp = new int[n];
		
		for(int i = 0; i < n; i++)
			d[i][i] = 2;
		
		palin(0,n-1);
		System.out.print(solve(0));
	}
	
	static int solve(int from) {
		if(from==n) return 0;
		if(dp[from]==0) {
			dp[from] = 2501;
			for(int i = n-1; i >= from; i--) {
				if(d[from][i]==2) {
					dp[from] = min(dp[from],1+solve(i+1));
				}
			}
		}
		return dp[from];
	}
	
	static int palin(int l, int r) {
		if(r<l) return 2;
		if(d[l][r]==0) {
			d[l][r] = 1;
			if(c[l]==c[r])
				d[l][r] = palin(l+1,r-1);
			palin(l,r-1); palin(l+1,r);
		}
		
		return d[l][r];
	}
	
	static int min(int i ,int j) {
		return i<j?i:j;
	}
}
