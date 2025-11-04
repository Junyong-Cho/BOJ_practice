import java.io.IOException;

public class BOJ_11444{
	
	static long n, ans[][];
	static int c;
	static final int DIV = 1_000_000_007;
	
	public static void main(String catchsunpie[]) throws IOException{
		n = System.in.read()&0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		ans = matrix(pow(n-1,new long[][]{{1,1},{1,0}}),new long[][] {{1},{0}});
		
		System.out.println(ans[0][0]);
	}
	
	static long[][] pow(long n, long a[][]) {
		if(n==0) return new long[][] {{1},{0}};
		if(n==1) return a;
		long res[][] = pow(n>>1,a);
		res = matrix(res,res);
		if((n&1)==1)
			return matrix(a,res);
		return res;
	}
	
	static long[][] matrix(long a[][], long b[][]) {
		long res[][] = new long[a.length][b[0].length];
		
		for(int i = 0; i < a.length; i++) {
			for(int j = 0; j < b[0].length; j++) {
				for(int p = 0; p < a[0].length; p++)
					res[i][j] = (res[i][j]+a[i][p]*b[p][j])%DIV;
			}
		}
		
		return res;
	}
	
}
