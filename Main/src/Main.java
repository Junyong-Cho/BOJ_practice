import java.io.IOException;

public class Main {
	
	static int n, dp[], goal;
	
	//boj.kr/2482
	static public void main(String catchsunpie[]) throws IOException{
		n = nex();
		dp = new int[n>>1];
		if(n%2==0) dp[n>>1] = 2;
		else dp[n>>1] = n;
		
		goal = nex();
	}
	
	static int nex() throws IOException{
		int n, c;
		while((n = System.in.read())<=' ');
		n &= 0b1111;
		while((c = System.in.read())>='0')
			n = (n<<3) + (n<<1) + (c&0b1111);
		return n;
	}
}
